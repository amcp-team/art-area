import { Component, OnInit } from "@angular/core";
import { getPin } from "../../model/getPin";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { BoardService } from "../../service/board.service";

@Component({
  selector: "app-board-pins",
  templateUrl: "./board-pins.component.html",
  styleUrls: ["./board-pins.component.scss"]
})
export class BoardPinsComponent implements OnInit {
  Pins$: Observable<getPin[]>;
  boardId: string;

  constructor(
    private boardService: BoardService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params => {
      this.boardId =
        params["username"] +
        "." +
        params["project"] +
        "." +
        (<string>params["board"]).toLowerCase().replace(" ", "-");
    });
  }

  ngOnInit() {
    this.loadPins();

    this.Pins$.subscribe(x => console.log(x));
  }

  loadPins() {
    this.Pins$ = this.boardService.getPins(this.boardId);
  }
}
