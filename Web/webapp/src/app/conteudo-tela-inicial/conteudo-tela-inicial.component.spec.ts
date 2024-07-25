import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConteudoTelaInicialComponent } from './conteudo-tela-inicial.component';

describe('ConteudoTelaInicialComponent', () => {
  let component: ConteudoTelaInicialComponent;
  let fixture: ComponentFixture<ConteudoTelaInicialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConteudoTelaInicialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ConteudoTelaInicialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
