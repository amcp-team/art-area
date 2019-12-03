namespace ArtArea.Desktop.Api.Handlers

open Microsoft.AspNetCore.Authentication
open Microsoft.AspNetCore.Authentication.JwtBearer
open Microsoft.IdentityModel.Tokens
open System.Text
open Giraffe.Auth
open Giraffe
open FSharp.Control.Tasks.V2
open Microsoft.AspNetCore.Http
open ArtArea.Web.Data.Interface
open System.Collections.Generic
open ArtArea.Models

module AuthConfiguration =

    let authenticationOptions (options: AuthenticationOptions) =
        options.DefaultAuthenticateScheme <- JwtBearerDefaults.AuthenticationScheme
        options.DefaultChallengeScheme <- JwtBearerDefaults.AuthenticationScheme
        options.DefaultScheme <- JwtBearerDefaults.AuthenticationScheme

    let jwtBearerOptions (options: JwtBearerOptions) =
        options.SaveToken <- true
        options.IncludeErrorDetails <- true
        options.TokenValidationParameters <-
            TokenValidationParameters
                (ValidateIssuer = false, ValidateAudience = false, ValidateLifetime = false,
                 ValidateIssuerSigningKey = false, ValidIssuer = "ArtArea.Desktop.Api",
                 ValidAudience = "ArtArea.Desktop",
                 IssuerSigningKey = SymmetricSecurityKey(Encoding.UTF8.GetBytes("ArtAreaApplicationSecreteKey")))

module AuthModels =

    type LoginModel =
        { username: string
          password: string }

    type LoginTokenResul =
        { Token: string }

open AuthModels
open System.Security.Claims
open System.IdentityModel.Tokens.Jwt
open Microsoft.FSharp.Linq
open System

module AuthHandler =

    let userLoggedIn (users: seq<User>) (user: LoginModel): bool =
        users |> Seq.exists (fun u -> u.Username = user.username && u.Password = user.password)

    let authorize: HttpFunc -> HttpContext -> HttpFuncResult =
        requiresAuthentication (challenge JwtBearerDefaults.AuthenticationScheme)

    let authorize2 =
        fun (next: HttpFunc) (context: HttpContext) ->
            try
                let authHeader = context.Request.Headers.["Authorization"]
                if not <| obj.ReferenceEquals(authHeader, null) && authHeader.Count > 0 then
                    let bearerAuth = authHeader.[0]
                    if not <| obj.ReferenceEquals(bearerAuth, null) then
                        let token = JwtSecurityTokenHandler().ReadJwtToken(bearerAuth.[7..])
                        let nameClaim = token.Claims |> Seq.find (fun x -> x.Type = ClaimTypes.Name)
                        let username = nameClaim.Value
                        let users = context.GetService<IUserRepository>().ReadUsers()
                        if users |> Seq.exists (fun u -> u.Username = username) then next context
                        else setStatusCode 401 next context
                    else
                        setStatusCode 401 next context
                else
                    setStatusCode 401 next context
            with _ -> setStatusCode 401 next context

    let unauthorized: HttpFunc -> HttpContext -> HttpFuncResult = setStatusCode 401 >=> text "Access Denied"

    let generateToken username =
        let claims = [ Claim(ClaimTypes.Name, username) ]

        let expires = Nullable()
        let notBefore = Nullable()
        let securityKey = SymmetricSecurityKey(Encoding.UTF8.GetBytes("ArtAreaApplicationSecreteKey"))
        let signingCredentials = SigningCredentials(key = securityKey, algorithm = SecurityAlgorithms.HmacSha256)

        let token =
            JwtSecurityToken
                (issuer = "ArtArea.Desktop.Api", audience = "ArtArea.Desktop", claims = claims, expires = expires,
                 notBefore = notBefore, signingCredentials = signingCredentials)

        { Token = JwtSecurityTokenHandler().WriteToken(token) }


    let login =
        fun (next: HttpFunc) (context: HttpContext) ->
            task {
                let! userLogin = context.BindJsonAsync<LoginModel>()
                let users = context.GetService<IUserRepository>().ReadUsers()

                if (not <| obj.ReferenceEquals(userLogin, null) && userLoggedIn users userLogin) then
                    let token = generateToken userLogin.username
                    return! json token next context
                else
                    return! setStatusCode 401 next context
            }

    let processToken =
        fun (next: HttpFunc) (context: HttpContext) ->
            let tokenString = context.Request.Headers.["Authorization"].[0].[7..]

            let token = JwtSecurityTokenHandler().ReadJwtToken(tokenString)

            json (tokenString, token) next context
 