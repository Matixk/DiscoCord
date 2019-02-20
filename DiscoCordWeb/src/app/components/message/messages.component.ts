import { Component, OnInit } from '@angular/core';
import { IMessage } from 'src/app/models/messages/message';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  messages: IMessage[];

  constructor() { }

  ngOnInit() {
  }

}
