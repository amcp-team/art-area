import { Component, OnInit } from '@angular/core';
import { PinService } from "../../service/pin.service";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { Data } from '@angular/router';

@Component({
  selector: 'app-pin-img',
  templateUrl: './pin-img.component.html',
  styleUrls: ['./pin-img.component.scss']
})
export class PinImgComponent implements OnInit {
  pinId: string;
  base64: string;
  someString = "data:image/png;base64,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"

  constructor (
    private pinService: PinService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params => {
      this.pinId =
      params["pin"]
    });
  }


  

  ngOnInit() {
    // this.base64 = this.pinService.getPicture();
  }

  

}
