import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServersComponent } from './servers.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { HttpClientModule } from '@angular/common/http';

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
    HttpClientModule
  ],
  exports: [ ServersComponent ]
})
export class ServersModule { }
