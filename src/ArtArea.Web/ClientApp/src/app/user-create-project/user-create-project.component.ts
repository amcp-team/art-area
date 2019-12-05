import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { UserService } from "../service/user.service";

@Component({
  selector: "app-user-create-project",
  templateUrl: "./user-create-project.component.html",
  styleUrls: ["./user-create-project.component.scss"]
})
export class UserCreateProjectComponent implements OnInit {
  createProjectForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.createProjectForm = this.formBuilder.group({
      title: ["", Validators.required],
      description: ["", Validators.required],
      privacy: [false , Validators.required],
    });
  }

  get form() {
    return this.createProjectForm.controls;
  }

  onSubmit() {
    this.userService
      .add(this.form.title.value, this.form.description.value, this.form.privacy.value)
      .pipe(first());
  }
}
