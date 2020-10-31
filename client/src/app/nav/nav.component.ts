import { Component, OnInit } from '@angular/core';
import { User } from '../models/User';
import {  AccountService } from "../services/account.service";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model : any = {};

  // If you need to access accountService in Template also, then make it public.
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {

  }

  login()
  {
   this.accountService.login(this.model).subscribe(response=>{

    console.log(response);
    
   },error=>{
  
     alert(error);
   });
  }

  logout()
  {
    this.accountService.logout();
  }

}
