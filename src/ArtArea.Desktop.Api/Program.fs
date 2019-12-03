// Learn more about F# at http://fsharp.org

// ----- PROJECT STRUCTURE -----
//  Program.fs : configures & initializes server
//  Router.fs : configures routes based on handlers
//  Handlers
//  |--- AuthHandler.fs : all http handlers & everything needed for authentication with JWT
//  |--- ProjectHandler.fs
//  |--- UserHandler.fs
//  |--- ProjectHandler.fs
//  |--- BoardHandler.fs
//  |--- PinGroupHandler.fs
//  |--- PinHandler.fs

open System
open Giraffe
open Microsoft.AspNetCore.Authentication
open Microsoft.Extensions.DependencyInjection
open ArtArea.Desktop.Api.Routes
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open ArtArea.Desktop.Api.Handlers.AuthConfiguration
open ArtArea.Web.Data.Interface
open Microsoft.AspNetCore.Authentication.JwtBearer
open ArtArea.Web.Data.Mock

let configureServices (services : IServiceCollection) =
    services
        .AddGiraffe()
        .AddAuthentication(authenticationOptions)
        .AddJwtBearer(Action<JwtBearerOptions> jwtBearerOptions) |> ignore
    // injecting repositories
    services.AddTransient<IUserRepository, UserRepositoryMock>() |> ignore
    services.AddTransient<IBoardRepository, BoardRepositoryMock>() |> ignore
    services.AddTransient<IProjectRepository, ProjectRepositoryMock>() |> ignore


let configureApp(app : IApplicationBuilder) =
    app.UseGiraffe Router.routes

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .UseUrls("http://localhost:5001/")
        .Build()
        .Run()
    0
