import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    exports: [
        MatIconModule,
        MatToolbarModule,
        MatListModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpClientModule,
    ]
})
export class SharedModule { }