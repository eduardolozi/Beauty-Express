import { Component, OnInit } from '@angular/core';
import { ToolbarTelaInicialComponent } from '../toolbar-tela-inicial/toolbar-tela-inicial.component';
import { Estabelecimento, EstabelecimentoService } from '../servicos/estabelecimento.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [ToolbarTelaInicialComponent],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {
  estabelecimentos: Estabelecimento[] = [];
  constructor(private estabelecimentoService: EstabelecimentoService) { }
  ngOnInit(): void {
    this.estabelecimentoService.obterTodos()
     .subscribe(estabelecimentos => this.estabelecimentos = estabelecimentos);
  } 
  
}
