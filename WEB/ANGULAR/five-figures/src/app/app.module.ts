import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CircleComponent } from './circle/circle.component';
import { SquareComponent } from './square/square.component';
import { StarComponent } from './star/star.component';
import { TriangleComponent } from './triangle/triangle.component';
import { OvalComponent } from './oval/oval.component';

@NgModule({
  declarations: [
    AppComponent,
    CircleComponent,
    SquareComponent,
    StarComponent,
    TriangleComponent,
    OvalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
