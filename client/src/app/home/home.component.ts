import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  regsiterMode = false;

  constructor() { }

  ngOnInit(): void {
  }

  toggleRegisterMode()
  {
    this.regsiterMode= !this.regsiterMode;
  }

}
