import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { ProjectService } from "../service/project.service";
import { NewBoard } from "../model/newBoard"


@Component({
  selector: 'app-project-create-board',
  templateUrl: './project-create-board.component.html',
  styleUrls: ['./project-create-board.component.scss']
})
export class ProjectCreateBoardComponent implements OnInit {
  model = new NewBoard('', '', false);

  constructor(
    private projectService: ProjectService,
  ) { }

  ngOnInit() {
    
  }

  

  onSubmit() {
    console.log(this.model.title, this.model.description, this.model.privacy)
    this.projectService
      .postBoard(this.model.title, this.model.description, this.model.privacy)
      .pipe(first())
      
  }

}
