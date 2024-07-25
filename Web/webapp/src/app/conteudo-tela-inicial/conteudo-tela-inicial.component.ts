import { Component } from '@angular/core';
import { CardApresentacaoComponent } from '../card-apresentacao/card-apresentacao.component';

@Component({
  selector: 'app-conteudo-tela-inicial',
  standalone: true,
  imports: [CardApresentacaoComponent],
  templateUrl: './conteudo-tela-inicial.component.html',
  styleUrl: './conteudo-tela-inicial.component.css'
})
export class ConteudoTelaInicialComponent {

}
