import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";

export interface Login {
    nomeouemail: string;
    senha: string;
}

@Injectable({providedIn: "root"})
export class LoginService {
    headers = new HttpHeaders({
        'Content-Type':  'application/json',
        Authorization: localStorage.getItem('token') || ""
    });
    apiUrl = 'https://localhost:7251/api/Login';
    sufixoValidarToken = '/validarToken';
    constructor(private http: HttpClient){}

    login(login: Login): Observable<string> {
        var params = new HttpParams()
                            .set('nomeouemail', login.nomeouemail)
                            .set('senha', login.senha);

        return this.http.get<string>(this.apiUrl, {headers: this.headers, params: params, responseType: 'text' as 'json'})
    }

    tokenValido(): Observable<number>{
        var token = localStorage.getItem('token');
        var url = this.apiUrl + this.sufixoValidarToken;
        var params = new HttpParams().set('token', token!);
        return this.http.get(url, {params: params, observe: 'response'})
        .pipe(
            map(response => response.status),
        );
    }
}