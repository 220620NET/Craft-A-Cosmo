import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserLogin } from '../models/UserLogin';
import { UserRegister } from '../models/UserRegister';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Injectable } from '@angular/core';
import { ConditionalExpr } from '@angular/compiler';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private fb:FormBuilder) { }
  mode:string = 'login';
  roles =[{name:"User"},{name:"Admin"}];
  email:FormControl=new FormControl('',[Validators.required]);
  password:FormControl=new FormControl('',[Validators.required]); 
  username:FormControl=new FormControl('');
  role:string = 'User';
  login():void{
    let user:UserLogin={
      name:'name',
      password:this.password.value
    };
    if(this.email.value){
      console.log('here in email')
      user.name=this.email.value;
    }else if(this.username.value){
      console.log('here in username')
      user.name=this.username.value;
    }
    console.log(user)
  }
  register():void{
    let ur:UserRegister={
      Email: this.email.value,
      username: this.username.value,
      password: this.password.value,
      role:this.role 
    };
    console.log(ur)
  }
  switchRole(role:string):void{
    this.role=role
  }
  switchMode(a:string):void{
    this.mode=a;
  }
  ngOnInit(): void {
  }

}
