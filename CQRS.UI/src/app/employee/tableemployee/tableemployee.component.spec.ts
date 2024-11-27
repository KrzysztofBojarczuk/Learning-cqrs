import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableemployeeComponent } from './tableemployee.component';

describe('TableemployeeComponent', () => {
  let component: TableemployeeComponent;
  let fixture: ComponentFixture<TableemployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TableemployeeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TableemployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
