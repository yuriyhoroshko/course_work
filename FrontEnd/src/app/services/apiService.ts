import { HttpClient, HttpHeaders } from '@angular/common/http';
import BaseUrl from '../../baseUrl';
import { Injectable } from '@angular/core';

const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json', Authorization: `Bearer ${sessionStorage.getItem('token')}`})
};

@Injectable({
  providedIn: 'root'
})

export default class ApiService {
    private client: HttpClient;
    constructor(private httpClient: HttpClient) {
        this.client = httpClient;
    }

    public apiPost = async <T>(body: any, url: string): Promise<T> => {
        let modelJson = JSON.stringify(body);

        return await this.client.post(`${BaseUrl}${url}`, modelJson, httpOptions).toPromise()
        .then((response: T) => response).catch(err => {
            console.error(err);
            return null;
            });
    }

    public apiGet = async <T>(url: string): Promise<T> => {
        return this.client.get(`${BaseUrl}${url}`, httpOptions).toPromise()
        .then((response: T) => response).catch(err => {
            console.error(err);
            return null;
            });
    }
}
