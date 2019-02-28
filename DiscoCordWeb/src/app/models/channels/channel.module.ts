import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChannelsComponent } from './channels.component';
import { MessageModule } from '../messages/message.module';

@NgModule({
  declarations: [
    ChannelsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MessageModule,
  ],
  exports: [ ChannelsComponent ]
})
export class ChannelsModule { }
