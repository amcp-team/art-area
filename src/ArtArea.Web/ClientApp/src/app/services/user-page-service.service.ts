import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UserPageModel } from '../models/userpage';


@Injectable({
  providedIn: 'root'
})
export class UserPageServiceService {

  userPageUrl: string;
  userApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  }

  constructor(private http: HttpClient) {
    this.userPageUrl = '/';
    this.userApiUrl = 'api/UserPage/'
   }

   getUserInfo(UId: number): Observable<UserPageModel>{
     return this.http.get<UserPageModel>(this.userPageUrl + this.userApiUrl + UId)
     .pipe(
       retry(1),
       catchError(this.errorHandler)       
     );
   }

   errorHandler(error) {
    let errorMessage = 'You are dumbhead and have error';
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
