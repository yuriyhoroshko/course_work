import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CounterChartComponent } from './counter-chart.component';

describe('CounterChartComponent', () => {
  let component: CounterChartComponent;
  let fixture: ComponentFixture<CounterChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CounterChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CounterChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
