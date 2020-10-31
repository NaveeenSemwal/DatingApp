import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './models/User';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client';
  users : any;

  constructor(private http : HttpClient, private accountService : AccountService){}
  
  ngOnInit(): void {
    
   // this.getUsers();

    this.setCurrentUser();
   
  }

  setCurrentUser()
  {
    const user : User = JSON.parse(localStorage.getItem("user"));
    this.accountService.setCurrentUser(user);
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
