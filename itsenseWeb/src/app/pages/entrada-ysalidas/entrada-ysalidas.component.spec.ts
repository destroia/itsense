import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntradaYSalidasComponent } from './entrada-ysalidas.component';

describe('EntradaYSalidasComponent', () => {
  let component: EntradaYSalidasComponent;
  let fixture: ComponentFixture<EntradaYSalidasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntradaYSalidasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EntradaYSalidasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
