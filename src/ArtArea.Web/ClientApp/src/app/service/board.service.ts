import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";

import { Board } from "../model/board";
import { Pin } from "../model/pin";
import { getPin } from "../model/getPin";

@Injectable({
  providedIn: "root"
})
export class BoardService {
  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8"
    })
  };

  constructor(private http: HttpClient) {}

  getBoardData(id: string): Observable<Board> {
    return this.http
      .get<Board>("api/board/data/" + id, this.httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  getPins(id: string): Observable<getPin[]> {
    return this.http
      .get<getPin[]>("api/board/pins/" + id, this.httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  postPin(formData: FormData, boardId: string) {
    console.log("post pin");
    return this.http
      .post("api/pin/create/" + boardId, formData)
      .pipe(catchError(this.errorHandler));
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
