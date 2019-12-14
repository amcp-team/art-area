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
open ArtArea.Web.Data.Repositories
open ArtArea.Web.Data
open Microsoft.Extensions.Configuration
open ArtArea.Web.Data.Config

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore
    services.AddTransient<IUserRepository, UserRepository>() |> ignore
    services.AddTransient<IBoardRepository, BoardRepository>() |> ignore
    services.AddTransient<IProjectRepository, ProjectRepository>() |> ignore
    services.AddTransient<IMessageRepository, MessageRepository>() |> ignore
    services.AddTransient<IPinRepository, PinRepository>() |> ignore
    services.AddTransient<IFileRepository, FileRepository>() |> ignore
    services.AddSingleton<ApplicationDb>() |> ignore
    ApplicationDbConfig (Database = "ArtAreaDb", Host = "localhost", Port = 27017, User = "root", Password = "example") 
        |> services.AddSingleton |> ignore
    

let configureApp(app : IApplicationBuilder) =
    app.UseGiraffe Router.routes

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .UseUrls("http://localhost:27018/")
        .Build()
        .Run()
    0
