namespace ArtArea.Desktop.Api.Routes

open Giraffe
open Microsoft.AspNetCore.Http
open ArtArea.Desktop.Api.Handlers.AuthHandler
open ArtArea.Desktop.Api.Handlers.ProjectHandler

module Router =

    let routes: HttpFunc -> HttpContext -> HttpFuncResult =
        choose
            [ POST >=> route "/api/login" >=> login
              GET >=> choose
                          [ route "/api/auth" >=> authorize >=> processToken
                            routef "/api/projects/%s" getUserProjects ] ]
