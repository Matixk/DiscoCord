import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChannelsComponent } from './channels.component';

@NgModule({
  declarations: [
    ChannelsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'servers/channels', pathMatch: 'full', component: ChannelsComponent },
      { path: 'servers/channels/:id', pathMatch: 'full', component: ChannelsComponent }
    ]),
    SharedModule,
  ],
  exports: [ ChannelsComponent ]
})
export class ChannelsModule { }
