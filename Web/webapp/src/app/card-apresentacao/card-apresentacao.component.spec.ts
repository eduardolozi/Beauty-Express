import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardApresentacaoComponent } from './card-apresentacao.component';

describe('CardApresentacaoComponent', () => {
  let component: CardApresentacaoComponent;
  let fixture: ComponentFixture<CardApresentacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardApresentacaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardApresentacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
