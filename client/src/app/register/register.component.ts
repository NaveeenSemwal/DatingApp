import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model : any ={};

  constructor() { }

  ngOnInit(): void {
  }

  regsiter()
  {
   console.log(this.model);
  }


  cancel()
  {
    console.log("Canceled !");
  }
   

}
