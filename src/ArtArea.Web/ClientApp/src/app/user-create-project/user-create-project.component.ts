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
  CreateProjectForm: FormGroup;
  actionType: string;
  returnUrl: string;
  Title: string;
  Description: string;
  error = "";
  username: string;
  
  constructor(
    private formBuilder: FormBuilder, 
    private route: ActivatedRoute, 
    private router: Router,
    private userService: UserService,
    ) 
    {
      this.actionType = 'Add';
      this.Title = 'title';
      this.Description = 'description';
      this.route.params.subscribe(params => {
        this.username = params["username"];

        this.CreateProjectForm = this.formBuilder.group(
          {
            title: ['', [Validators.required]],
            body: ['', [Validators.required]],
          }
        )
      });

      this.Title = this.route.snapshot.params[this.Title];
      this.Description = this.route.snapshot.params[this.Description];
    }

  
  ngOnInit() {
    this.CreateProjectForm = this.formBuilder.group({
      title: ["", Validators.required],
      description: ["", Validators.required]
    });
  }
      

  get form() {
    return this.CreateProjectForm.controls;
  }

  onSubmit() {

    this.userService
      .add(this.form.title.value, this.form.description.value)
      .pipe(first())
  }

}
