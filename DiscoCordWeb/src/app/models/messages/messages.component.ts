import { Component, OnInit } from "@angular/core";
import { IMessage } from "./message";
import { MessageService } from "./message.service";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: "app-messages",
  templateUrl: "./messages.component.html",
  styleUrls: ["./messages.component.css"]
})
export class MessagesComponent implements OnInit {
  errorMessage: string;
  messages: IMessage[];
  id: number;

  _newMessageContent: string;
  set newMessageContent(value: string) {
    this._newMessageContent = value;
  }

  constructor(private readonly messageService: MessageService,
    private readonly route: ActivatedRoute) { }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get("id");
    if (param) {
      this.id = +param;
      this.getMessages(this.id);
    }
  }

  getMessages(id: number) {
    this.messageService.getMessages(id).subscribe(
      messages => this.messages = messages,
      error => this.errorMessage = error);
  }

  onSendClicked(): void {
    this.messageService.sendMessage(this.id, this.newMessageContent);
  }
}
