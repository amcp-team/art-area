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
open ArtArea.Desktop.Api.Handlers.AuthHandler
open System.Collections.Generic
open ArtArea.Models

module ProjectHandler =

    type ProjectResponseModel =
        { Id: string
          Title: string }

    let getUserProjects (username: string) =
        authorize >=> fun (next: HttpFunc) (context: HttpContext) ->
            task {
                let projects = context.GetService<IProjectRepository>().ReadProjects()

                let userProjects =
                    query {
                        for project in projects do
                            where
                                (project.HostUsername = username || query {
                                                                        for collaborator in project.Collaborators do
                                                                            select collaborator.Username
                                                                            contains username
                                                                    })
                            select
                                ({ Id = project.Id
                                   Title = project.Title })
                    }
                return! json userProjects next context
            }
