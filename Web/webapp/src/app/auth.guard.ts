import { Injectable } from '@angular/core';
import {CanActivateFn ,ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { LoginService } from './login/login.service'; 
import { map, catchError, of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard {
  constructor(private loginService: LoginService, private router: Router) {}
    podeNavegar(): Observable<boolean> {
        return this.loginService.tokenValido().pipe(
          map(codigo => {
            if (codigo === 200) {
              return true;
            } else {
              this.router.navigate(['/home']);
              return false;
            }
          }),
          catchError((error) => {
            this.router.navigate(['/home']);
            return of(false);
          })
        );
    }
}
