import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent {
  registerFail: boolean = false;
  constructor(private router: Router, private http: HttpClient) { }

  public Register = (form: NgForm) => {
    let body = JSON.stringify(form.value);
    this.http.post("http://localhost:5000/api/auth/register", body, {
      headers: new HttpHeaders({
        "Content-Type": "application/json;"
      })
    })
      .subscribe(
        response => {
          let username = (<any>response).username;
          let token = (<any>response).token;
          localStorage.setItem("jwt", token);
          this.router.navigate(["/user/" + username]);
        },
        error => {
          this.registerFail = true;
        })
  }
}
