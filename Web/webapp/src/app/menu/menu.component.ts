import { Component, importProvidersFrom, OnInit } from '@angular/core';
import { ToolbarTelaInicialComponent } from '../toolbar-tela-inicial/toolbar-tela-inicial.component';
import { AuthGuard } from '../auth.guard';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [ToolbarTelaInicialComponent],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {

  constructor(private authGuard: AuthGuard) { }
  ngOnInit(): void {
    this.authGuard.podeNavegar();
  } 
  
}
