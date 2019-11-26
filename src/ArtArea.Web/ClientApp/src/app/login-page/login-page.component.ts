import { Component } from '@angular/core';
import { UserLogin } from '../models/user-login.model';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserLoginResponse } from '../models/user-login-response';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  loginSuccessfull:boolean = true;

  constructor(private http: HttpClient, private router: Router) { }

  public Login = (form: NgForm) => {
    let userLogin = JSON.stringify((<UserLogin>form.value));
    this.http.post("http://localhost:5000/api/auth/login", userLogin, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    })
    .subscribe(response =>
      {
        var loginResult = (<UserLoginResponse>response);
        console.log(loginResult);
        this.loginSuccessfull = loginResult.Successfull;
        localStorage.setItem("jwt", loginResult.Token);
        this.router.navigate(["/user/" + loginResult.Username]);
      },
      error => {
        console.log(<UserLoginResponse>error);
        this.loginSuccessfull = false;
      })

  }
}
