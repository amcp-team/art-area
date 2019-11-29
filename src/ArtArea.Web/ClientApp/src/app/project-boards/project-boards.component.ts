import { Component, OnInit } from '@angular/core';
import { Project } from '../model/project';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectService } from '../service/project.service';
import { Board } from '../model/board'

@Component({
  selector: 'app-project-boards',
  templateUrl: './project-boards.component.html',
  styleUrls: ['./project-boards.component.scss']
})
export class ProjectBoardsComponent implements OnInit {
  Boards$: Observable<Board[]>
  title: string;



  constructor(private projectService:ProjectService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.title = params['title'];
    })
  }

  ngOnInit() {
    this.loadBoards();

    this.Boards$.subscribe(x => console.log(x));
  }

  loadBoards(){
    this.Boards$ = this.projectService.getBoards(this.title);
  }

}
