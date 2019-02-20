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

  constructor(private readonly messageService: MessageService,
    private readonly route: ActivatedRoute) { }

  ngOnInit() {
    const param = this.route.snapshot.paramMap.get("id");
    if (param) {
      const id = +param;
      this.getMessages(id);
    }
  }

  getMessages(id: number) {
    this.messageService.getMessages(id).subscribe(
      messages => this.messages = messages,
      error => this.errorMessage = error);
  }
}
