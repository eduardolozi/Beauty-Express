import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToolbarTelaInicialComponent } from './toolbar-tela-inicial.component';

describe('ToolbarTelaInicialComponent', () => {
  let component: ToolbarTelaInicialComponent;
  let fixture: ComponentFixture<ToolbarTelaInicialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ToolbarTelaInicialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ToolbarTelaInicialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
