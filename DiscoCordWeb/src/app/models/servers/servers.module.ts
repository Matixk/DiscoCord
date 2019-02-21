import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServersComponent } from './servers.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    ServersComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "servers", component: ServersComponent },
      { path: "servers/:id", component: ServersComponent }
    ])
  ]
})
export class ServersModule { }
