import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServersComponent } from './servers.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChannelsModule } from '../channels/channel.module';

@NgModule({
  declarations: [
    ServersComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ChannelsModule,
  ],
  exports: [ ServersComponent ]
})
export class ServersModule { }
