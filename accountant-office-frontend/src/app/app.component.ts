import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { User } from 'oidc-client-ts';
import { filter } from 'rxjs/operators';
import { AuthService } from './core/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit{
  public title = 'accountant-office-front';
  public departmentId = "";
  public section = "";
  public user: User | null = null;

  public constructor(private router: Router, private authService: AuthService) {
    router.events.pipe(
      filter(nav => nav instanceof NavigationStart)
    ).subscribe(params => {
      const nav = params as NavigationStart;
      const arr = nav.url.split("/");
      this.section = arr[1];
      this.departmentId = (arr.length === 3 && arr[1] === "departments") ? arr[2] : ""
    });

    this.authService.subscribeToUserLoad((user) => {this.user = user});
  }

  public ngOnInit(): void {
    this.authService.getUser().subscribe(user => this.user = user);
  }

  public onLogin() {
    this.authService.login()
    .subscribe({error: console.log});
  }

  public onLogOut() {
    this.authService.logout();
  }
}
