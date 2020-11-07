import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators'

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
    
      catchError(error=>{
       if (error) {
         console.log("THIS IS FROM ERROR INTERCEPTOR.");
        console.log(error)

        switch (error.status) {
          case 400:
            
            break;
        
          default:
            break;
        }

       }

       return throwError(error);

      })

    )
    return throwError("");
    
  }
}
