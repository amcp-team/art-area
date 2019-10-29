open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Hosting

let routes =
    choose [
        route "/" >=> text "Hello World from F#!"
    ]

let configureApp(app:IApplicationBuilder) =
    app.UseGiraffe routes

let configureServices(services:IServiceCollection) =
    services.AddGiraffe |> ignore

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(configureApp)
        .ConfigureServices(configureServices)
        .Build()
        .Run()
    0
