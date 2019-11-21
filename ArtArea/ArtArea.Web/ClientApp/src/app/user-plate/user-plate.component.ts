import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-plate',
  templateUrl: './user-plate.component.html',
  styleUrls: ['./user-plate.component.css']
})
export class UserPlateComponent implements OnInit {

  userInfo={
    name: "Sergey",
    description: "description"
  }

  constructor() { }

  ngOnInit() {
  }

}
