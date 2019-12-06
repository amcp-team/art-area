import { Component, OnInit } from "@angular/core";
import { PinService } from "../../service/pin.service";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { Message } from "../../model/message";


@Component({
  selector: 'app-pin-comments-list',
  templateUrl: './pin-comments-list.component.html',
  styleUrls: ['./pin-comments-list.component.scss']
})
export class PinCommentsListComponent implements OnInit {
  Messages$: Observable<Message[]>;
  pinId: string;

  constructor(
    private pinService: PinService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params =>{
      this.pinId = 
      params["username"] +
      "." +
      params["project"] +
      "." +
      params["board"] +
      "." +
      (<string>params["pin"]).toLowerCase().replace(" ", "-");
    })
   }

  ngOnInit() {
    this.loadMessages();

    this.Messages$.subscribe(x => console.log(x));

  }

  loadMessages(){
    this.Messages$ = this.pinService.getMessages(this.pinId)
  }

}
