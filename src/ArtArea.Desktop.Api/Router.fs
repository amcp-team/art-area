namespace ArtArea.Desktop.Api.Routes

open Giraffe
open Microsoft.AspNetCore.Http
open ArtArea.Desktop.Api.Handlers.AuthHandler

module Router =

    let routes: HttpFunc -> HttpContext -> HttpFuncResult = choose [ POST >=> route "/api/login" >=> login ]
