import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { UserService } from "../service/user.service";
import { NewProject } from "../model/newProject";
import { AuthenticationService } from "../app-auth/authentication.service";

@Component({
  selector: "app-user-create-project",
  templateUrl: "./user-create-project.component.html",
  styleUrls: ["./user-create-project.component.scss"]
})
export class UserCreateProjectComponent implements OnInit {
  createProjectForm: FormGroup;
  username: string;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private route : ActivatedRoute,
    private router : Router
  ) {}

  ngOnInit() {
    this.createProjectForm = this.formBuilder.group({
      title: ["", Validators.required],
      description: ["", Validators.required],
      privacy: [false, Validators.required]
    });
  }

  get form() {
    return this.createProjectForm.controls;
  }

  onSubmit() {
    console.log(this.form);
    if (this.createProjectForm.invalid) {
      return;
    }

    console.log(this.form.title, this.form.description, this.form.privacy);

    this.userService
      .postProject(
        this.form.title.value,
        this.form.description.value,
        this.form.privacy.value
      )
      .pipe(first())
      .subscribe(x => {
        // TODO route to created project page
        console.log(x);
        this.router.navigate(['username' + '/' + this.form.title])
      });
      
  }
}
