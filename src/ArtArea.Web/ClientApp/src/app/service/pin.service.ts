import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";

import { Pin } from "../model/pin";
import { Message } from "../model/message";
import { Data } from "@angular/router";
import { identifierModuleUrl } from "@angular/compiler";
import { Base64Image } from "../model/base64Imgae";

@Injectable({
  providedIn: "root"
})
export class PinService {
  httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json; charset=utf-8"
    })
  };

  constructor(private http: HttpClient) {}

  getMessages(id: string): Observable<Message[]> {
    return this.http
      .get<Message[]>("api/pin/messages/" + id, this.httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  getPicture(): any {
    return this.http
      .get("api/pin/image", this.httpOptions)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  getThumbnailBase64(id: string) {
    console.log("base64 method");
    console.log(id);
    return this.http
      .get<Base64Image>("api/pin/thumbnail/" + id, this.httpOptions)
      .pipe(catchError(this.errorHandler));
  }

  postMessage(formData: FormData, pinId: string) {
    console.log("post message");
    return this.http
      .post("api/pin/message/" + pinId, formData)
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
