import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MessagesComponent } from "./messages.component";
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    MessagesComponent
    ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  exports: [ MessagesComponent ]
})
export class MessageModule { }
