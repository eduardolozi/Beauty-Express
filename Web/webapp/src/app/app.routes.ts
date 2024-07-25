import { Routes } from '@angular/router';
import { TelaInicialComponent } from './tela-inicial/tela-inicial.component';
import { CadastroComponent } from './cadastro/cadastro.component';

export const routes: Routes = [
    {path: 'home', title: 'Home', component: TelaInicialComponent},
    {path: 'cadastro', title: 'Cadastro', component: CadastroComponent},
    {path: '', redirectTo: 'home', pathMatch: 'full'},
];