import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './layout/app.component';
import { ServersComponent } from './models/servers/servers.component';
import { ChannelsComponent } from './models/channels/channels.component';
import { MessagesComponent } from './models/messages/messages.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent
  },
  {
    path: ':id',
    component: ServersComponent,
    outlet: 'servers',
    children: [
      {
        path: ':id',
        component: ChannelsComponent,
        outlet: 'channels',
        children: [
          {
            path: ':id',
            component: MessagesComponent,
            outlet: 'messages',
          }
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
