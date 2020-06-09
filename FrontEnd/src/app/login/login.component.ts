import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import AuthenticationService from '../services/authenticationService';
import LoginModel from '../models/login-model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  private authService: AuthenticationService;

  private userName: string;
  private password: string;

  constructor(authService: AuthenticationService, private router: Router) {
    this.authService = authService;

    sessionStorage.removeItem('token');
  }

  public loginChanged = (event: any) => {
    this.userName = event.target.value;
  }

  public passwordChanged = (event: any) => {
    this.password = event.target.value;
  }

  public tryAuth = async (isReg: boolean) => {
    let authModel: LoginModel = {
      password: this.password,
      userName: this.userName
    };
    
    if(await this.authService.tryAuth(authModel, isReg)) {
      this.router.navigateByUrl('');
    } else {
      this.router.navigateByUrl('/login');
    }
  }

  ngOnInit(): void {
  }

}
