import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable, switchMap, map, of } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    
    return this.authService.getUser()
    .pipe(
      switchMap(user => {
        if(user?.access_token) {
          return of(user.access_token);
        } else if (user){
          return this.authService.renewToken()
          .pipe(
            map(renewedUser => renewedUser ? renewedUser.access_token : "")
          );
        }
        return this.authService.login()
        .pipe(
          switchMap(() => this.authService.getUser()),
          map(user => user ? user.access_token : "")
        );
      }),
      switchMap((accessToken : string) => {
        const headers = new HttpHeaders({
          Accept: 'application/json',
          Authorization: 'Bearer ' + accessToken
        });

        let clonedReq = request.clone({ headers })

        return next.handle(clonedReq);;
      })
    );
  }
}
