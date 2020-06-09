import { HttpClient, HttpHeaders } from '@angular/common/http';
import BaseUrl from '../../baseUrl';
import LoginModel from '../models/login-model';
import LoggedModel from '../models/logged-model';
import { Injectable } from '@angular/core';

const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})

export default class AuthenticationService {
    private client: HttpClient;
    constructor(private httpClient: HttpClient) {
        this.client = httpClient;
    }

    public tryAuth = async (loginModel: LoginModel, register: boolean): Promise<boolean> => {
        let modelJson = JSON.stringify(loginModel);

        return this.client.post(register ? `${BaseUrl}User/register` : `${BaseUrl}User/login`, modelJson, httpOptions).toPromise()
        .then((response: LoggedModel) => {
            sessionStorage.setItem('userName', response.userName);
            sessionStorage.setItem('token', response.token);
            return true;
        }).catch(() =>  false);
    }
}
