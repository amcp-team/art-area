import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { UserData } from "../model/userdata";
import { catchError, retry } from "rxjs/operators";
import { Project } from "../model/project";

@Injectable({
  providedIn: "root"
})
export class UserService {
  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8"
    })
  };

  constructor(private http: HttpClient) {}

  getUserData(username: string): Observable<UserData> {
    return this.http
      .get<UserData>("api/user/data/" + username, this.httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  getProjects(username: string): Observable<Project[]> {
    return this.http
      .get<Project[]>("api/user/projects/" + username, this.httpOptions)
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
