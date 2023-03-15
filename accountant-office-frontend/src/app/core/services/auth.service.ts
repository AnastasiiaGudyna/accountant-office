import { Injectable } from '@angular/core';
import { User, UserLoadedCallback, UserManager } from 'oidc-client-ts';
import { environment } from 'src/environments/environment';
import { from, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  userManager: UserManager;

  constructor() {
    const settings = {
      authority: environment.stsAuthority,
      client_id: environment.clientId,
      redirect_uri: `${environment.clientRoot}signin-callback`,
      silent_redirect_uri: `${environment.clientRoot}silent-callback.html`,
      post_logout_redirect_uri: `${environment.clientRoot}`,
      response_type: 'code',
      scope: environment.clientScope,
      client_secret: environment.clientSecret,
      loadUserInfo: true
    };
    this.userManager = new UserManager(settings);
  }

  public getUser(): Observable<User | null> {
    return from(this.userManager.getUser());
  }

  public login(): Observable<void> {
    return from(this.userManager.signinRedirect());
  }

  public renewToken(): Observable<User | null> {
    return from(this.userManager.signinSilent());
  }

  public logout(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  public subscribeToUserLoad(cb: UserLoadedCallback) {
    this.userManager.events.addUserLoaded(cb);
  }
}