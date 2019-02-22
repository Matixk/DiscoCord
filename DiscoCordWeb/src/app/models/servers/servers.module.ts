import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServersComponent } from './servers.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChannelsModule } from '../channels/channel.module';

@NgModule({
  declarations: [
    ServersComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'servers', pathMatch: 'full', component: ServersComponent },
      { path: 'servers/:id', pathMatch: 'full', component: ServersComponent }
    ]),
    SharedModule,
    ChannelsModule,
  ],
  exports: [ ServersComponent ]
})
export class ServersModule { }
