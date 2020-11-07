import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {  HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
// Template Form
import { FormsModule } from "@angular/forms"; 


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptor } from "./interceptors/error.interceptor";
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    TestErrorsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    BrowserAnimationsModule
    
  ],
  providers: [
{ provide : HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi:true }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
