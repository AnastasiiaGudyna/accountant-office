import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit{
  public title = 'accountant-office-front';
  public departmentId = "";

  public constructor(private router: Router) {
    router.events.pipe(
      filter(nav => nav instanceof NavigationStart)
    ).subscribe(params => {
      const nav = params as NavigationStart;
      const arr = nav.url.split("/");
      debugger
      this.departmentId = (arr.length === 3 && arr[1] === "departments") ? arr[2] : ""
    });
  }


  public ngOnInit(): void {
    
  }
}
