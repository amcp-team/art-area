import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

// TODO this component should work a bit better:
//     - we should get the route we are going to after successfull login to navigate to
//     - we should get a bit more sophisticated error result to show more acccurate output on login 

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  invalidLogin: boolean

  constructor(private http: HttpClient, private router: Router) { }

  public login = (form: NgForm) => {
    let credentials = JSON.stringify(form.value);
    this.http.post("http://localhost:5000/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(
      response => {
        let token = (<any>response).token;
        localStorage.setItem("jwt", token);
        this.invalidLogin = false;
        this.router.navigate(["/"]);
      },
      error => {
        this.invalidLogin = true;
      });
  }
}
