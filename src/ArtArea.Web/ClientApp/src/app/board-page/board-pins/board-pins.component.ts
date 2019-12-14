import { Component, OnInit } from "@angular/core";
import { getPin } from "../../model/getPin";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { BoardService } from "../../service/board.service";
import { PinService } from "src/app/service/pin.service";

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
    private route: ActivatedRoute,
    private pinService: PinService
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

  dataURItoBlob(dataURI) {
    const byteString = window.atob(dataURI);
    const arrayBuffer = new ArrayBuffer(byteString.length);
    const int8Array = new Uint8Array(arrayBuffer);
    for (let i = 0; i < byteString.length; i++) {
      int8Array[i] = byteString.charCodeAt(i);
    }
    const blob = new Blob([int8Array], { type: "image/jpeg" });
    return blob;
  }

  ngOnInit() {
    this.loadPins();

    this.Pins$.subscribe(x => console.log(x));
  }

  loadPins() {
    this.Pins$ = this.boardService.getPins(this.boardId);
  }

  loadThumbnail(id: string) {
    const base64 = this.pinService.getThumbnailBase64(id);

    console.log("got base64 of thumbnail");
    console.log(base64);

    let date = new Date().valueOf;
    let text = "";
    const possibleText =
      "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (let i = 0; i < 5; i++) {
      text += possibleText.charAt(
        Math.floor(Math.random() * possibleText.length)
      );
    }

    const imageName = date + "." + text + ".jpeg";
    console.log(imageName);

    const imageBlob = this.dataURItoBlob(base64);
    const imageFile = new File([imageBlob], imageName, { type: "image/jpeg" });
    const url = window.URL.createObjectURL(imageFile);
    console.log(url);

    return url;
  }
}
