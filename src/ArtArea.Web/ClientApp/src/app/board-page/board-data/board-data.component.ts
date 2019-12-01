import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { Board } from "../../model/board";
import { BoardService } from "../../service/board.service";

@Component({
  selector: "app-board-data",
  templateUrl: "./board-data.component.html",
  styleUrls: ["./board-data.component.scss"]
})
export class BoardDataComponent implements OnInit {
  boardData$: Observable<Board>;
  boardId: string;

  constructor(
    private boardService: BoardService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params => {
      this.boardId =
        params["username"] + "." + params["project"] + "." + params["board"];
    });
  }

  ngOnInit() {
    this.boardData$ = this.boardService.getBoardData(this.boardId);
  }
}
