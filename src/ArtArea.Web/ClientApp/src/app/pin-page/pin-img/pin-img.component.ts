import { Component, OnInit } from "@angular/core";
import { PinService } from "../../service/pin.service";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { Data } from "@angular/router";

@Component({
  selector: "app-pin-img",
  templateUrl: "./pin-img.component.html",
  styleUrls: ["./pin-img.component.scss"]
})
export class PinImgComponent implements OnInit {
  pinId: string;
  base64: string;

  constructor(private pinService: PinService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.pinId = params["pin"];
      console.log(this.pinId);
      this.pinService.getThumbnailBase64(this.pinId).subscribe(data => {
        this.base64 = data.base64;
        console.log(this.base64);
      });
    });
  }

  ngOnInit() {
    console.log(this.pinId);
  }
}
