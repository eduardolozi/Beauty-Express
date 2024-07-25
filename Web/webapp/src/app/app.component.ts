import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TelaInicialComponent } from './tela-inicial/tela-inicial.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TelaInicialComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'webapp';
}
