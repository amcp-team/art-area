import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-username-badge',
  templateUrl: './username-badge.component.html',
  styleUrls: ['./username-badge.component.css']
})
export class UsernameBadgeComponent implements OnInit {
  username: string;

  constructor(private http:HttpClient) { }

  ngOnInit() {
    this.http.get("http://localhost:5000/api/auth/username",
    {
      headers: new HttpHeaders({
        "Content-Type":"application/json"
      })
    })
    .subscribe(result => {
      this.username = (<any>result).username;
    })
  }
}
