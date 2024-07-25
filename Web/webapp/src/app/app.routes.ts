import { Routes } from '@angular/router';
import { TelaInicialComponent } from './tela-inicial/tela-inicial.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
    {path: '', component: TelaInicialComponent},
    {path: 'login', component: LoginComponent}
];
