import { Component, OnInit } from "@angular/core";
import {
  FormGroup,
  Validators,
  FormControl,
  FormBuilder
} from "@angular/forms";
import { BoardService } from "src/app/service/board.service";
import { toFormData } from "src/app/utils/toFormData";
import { NewPin } from "src/app/model/newPin";

@Component({
  selector: "app-board-create-pin",
  templateUrl: "./board-create-pin.component.html",
  styleUrls: ["./board-create-pin.component.scss"]
})
export class BoardCreatePinComponent implements OnInit {
  newPinForm: FormGroup;

  constructor(
    private boardService: BoardService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    this.newPinForm = this.formBuilder.group({
      message: [""],
      thumbnail: [""],
      sourceFile: [""]
    });
  }

  get form() {
    return this.newPinForm.controls;
  }

  onThumbnailUpload(event) {
    if (event.target.files.length > 0) {
      const thumbnail = event.target.files[0];
      this.newPinForm.get("thumbnail").setValue(thumbnail);
    }
  }

  onSourceFileUpload(event) {
    if (event.target.files.length > 0) {
      const sourceFile = event.target.files[0];
      this.newPinForm.get("sourceFile").setValue(sourceFile);
    }
  }

  onSubmit() {
    const formData = new FormData();
    formData.append("message", this.newPinForm.get("message").value);
    formData.append("thumbnail", this.newPinForm.get("thumbnail").value);
    formData.append("sourceFile", this.newPinForm.get("sourceFile").value);

    this.boardService.postPin(formData).subscribe(x => console.log(x));
  }
}
