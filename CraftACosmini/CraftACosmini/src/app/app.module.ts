import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormBuilder } from '@angular/forms';
import { Injectable } from '@angular/core';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    FormsModule,
    ReactiveFormsModule,
    FormControl,
    FormBuilder,
    Injectable
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
