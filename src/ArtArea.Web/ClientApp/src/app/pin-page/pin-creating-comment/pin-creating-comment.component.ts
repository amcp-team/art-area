import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { first } from "rxjs/operators";
import { PinService } from "../../service/pin.service";
import { Message } from "../../model/message";

@Component({
  selector: 'app-pin-creating-comment',
  templateUrl: './pin-creating-comment.component.html',
  styleUrls: ['./pin-creating-comment.component.scss']
})
export class PinCreatingCommentComponent implements OnInit {
  createMessageForm: FormGroup;
  pinId: string;

  constructor(
    private pinService: PinService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe(params => {
      this.pinId = 
      params["username"] +
      "." +
      params["project"] +
      "." +
      params["board"] +
      "." +
      "pin" +
      "." +
      (<string>params["pin"]).toLowerCase().replace(" ", "-");
    })
   }

  ngOnInit() {
    this.createMessageForm = this.formBuilder.group({
      message:["", Validators],
    });
  }

  get form() {
    return this.createMessageForm.controls;
  }

  onSubmit(){
    console.log();
    this.pinService
      .postMessage(
        this.form.message.value,
      )
      .pipe(first())
      console.log(this.form.message)
  }

}
