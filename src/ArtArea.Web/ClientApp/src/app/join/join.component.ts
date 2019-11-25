import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { HttpHeaders, HttpClient } from '@angular/common/http';

// TODO join component requires much more live functionality
//      - we need to show user that ones login is unavailable (live) 
//          back-end can provide undpoint that return boolean result
//      - we need to get a bit more sophisticated error data after registry attempt 

@Component({
  selector: 'app-join',
  templateUrl: './join.component.html',
  styleUrls: ['./join.component.css']
})
export class JoinComponent {
  successfulJoin: boolean;

  constructor(private http: HttpClient, private router: Router) { }

  public join = (form: NgForm) => {
    let credentials = JSON.stringify(form.value);

    this.http.post("http://localhost:5000/api/auth/join", credentials,
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json"
        })
      }).subscribe(
        response => {
          let token = (<any>response).token;
          localStorage.setItem("jwt", token);
          this.successfulJoin = true;
          this.router.navigate(["/"]);
        },
        error => {
          this.successfulJoin = false;
        })
  }

}
