import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  users : any;

  constructor(private http : HttpClient){}
  
  ngOnInit(): void {
    
    this.getUsers();
   
  }

// Create observer object Example

//   myObserver = {
//   next: response => this.users= response,
//   error: err => alert('Observer got an error: ' + err),
//   complete: () => console.log('Observer got a complete notification'),
// };

  getUsers()
  {
    this.http.get("https://localhost:5001/api/Users").subscribe(response => {

     this.users= response;
     console.log( this.users);
    },
    err => alert('Observer got an error: ' + err),
    () => console.log('Observer got a complete notification'));
  }
  
}
