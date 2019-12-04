import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthenticationService } from "../app-auth/authentication.service";
import { first } from "rxjs/operators";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.scss"]
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  error = "";

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthenticationService
  ) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username: ["", Validators.required],
      password: ["", Validators.required],
      email: ["", Validators.required],
      name: ["", Validators.required]
    });

    this.authService.logout();
  }

  get form() {
    return this.registerForm.controls;
  }

  onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    this.authService
      .register(
        this.form.username.value,
        this.form.password.value,
        this.form.email.value,
        this.form.name.value
      )
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(["/"]);
        },
        error => {
          this.error = error;
        }
      );
  }
}
