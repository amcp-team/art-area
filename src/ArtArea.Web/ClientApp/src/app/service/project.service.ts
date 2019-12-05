import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";

import { Project } from "../model/project";
import { Board } from "../model/board";

@Injectable({
  providedIn: "root"
})
export class ProjectService {
  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8"
    })
  };

  constructor(private http: HttpClient) {}

  getProjectData(id: string): Observable<Project> {
    return this.http
      .get<Project>("api/project/data/" + id, this.httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  getBoards(id: string): Observable<Board[]> {
    return this.http
      .get<Board[]>("api/project/boards/" + id, this.httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  postBoard(title: string, description: string){
    return this.http
    .post<string>("api/user/create", {
      title,
      description,
    })
    .pipe(retry(1), catchError(this.errorHandler)); 
  }

  errorHandler(error) {
    let errorMessage = "You are dumbhead and have error";
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
