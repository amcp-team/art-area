namespace ArtArea.Desktop.Api.Routes

open Giraffe
open Microsoft.AspNetCore.Http

module Router =

    let routes : HttpFunc -> HttpContext -> HttpFuncResult =
        choose [
            // place there api routes & bind them to handlers
        ]
