import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { MessagesComponent } from "./messages.component";

@NgModule({
  declarations: [
    MessagesComponent
    ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "messages/channel/:id", component: MessagesComponent },
      { path: "messages/:id", component: MessagesComponent }
    ])
  ]
})
export class MessageModule { }
