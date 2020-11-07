import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {

  baseURL ='https://localhost:5001/api/';

  constructor(private http : HttpClient) { }

  ngOnInit(): void {
  }

  get404Error()
  {
   return this.http.get(this.baseURL + 'error/not-found').subscribe(response=>{

    console.log(response);
   }, error=>{
     alert("404 Error "+ error);
   })
  }

  get400Error()
  {
   return this.http.get(this.baseURL + 'error/bad-request').subscribe(response=>{

    console.log(response);
   }, error=>{
     alert("400 Error "+ error);
   })
  }

  get500Error()
  {
   return this.http.get(this.baseURL + 'error/server-error').subscribe(response=>{

    console.log(response);
   }, error=>{
     alert("500 Error "+ error);
   })
  }

  get401Error()
  {
   return this.http.get(this.baseURL + 'error/auth').subscribe(response=>{

    console.log(response);
   }, error=>{
     alert("401 Error "+ error);
   })
  }

}
