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

    let jwtBearerOptions (options: JwtBearerOptions) =
        options.SaveToken <- true
        options.TokenValidationParameters <-
            TokenValidationParameters
                (ValidateIssuer = true, ValidateAudience = true, ValidateLifetime = false,
                 ValidateIssuerSigningKey = true, ValidIssuer = "ArtArea.Desktop.Api", ValidAudience = "ArtArea.Desktop",
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
 