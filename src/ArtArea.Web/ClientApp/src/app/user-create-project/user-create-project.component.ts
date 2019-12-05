import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { UserService } from "../service/user.service";
import { NewProject } from "../model/newProject"

@Component({
  selector: "app-user-create-project",
  templateUrl: "./user-create-project.component.html",
  styleUrls: ["./user-create-project.component.scss"]
})
export class UserCreateProjectComponent implements OnInit {
  
  model = new NewProject('', '', false);
 

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService
  ) {}

  ngOnInit() {
    
  }

  

  onSubmit() {
    console.log(this.model.title, this.model.description, this.model.privacy)
    this.userService
      .add(this.model.title, this.model.description, this.model.privacy)
    
    
  }

  get diagnostic() { return JSON.stringify(this.model); }
  
}
