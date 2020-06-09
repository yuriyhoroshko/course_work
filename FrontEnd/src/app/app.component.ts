import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'PerformanceCharts';

  constructor(private router: Router) { }

  ngOnInit() {
    if(!sessionStorage.getItem('token')) {
      let route = this.router.url;

      if(route !== '/login') {
        console.log('redirected to login page');
        this.router.navigateByUrl('/login');
      }
    }
  }
}
