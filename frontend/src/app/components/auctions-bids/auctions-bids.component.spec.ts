import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionsBidsComponent } from './auctions-bids.component';

describe('AuctionsBidsComponent', () => {
  let component: AuctionsBidsComponent;
  let fixture: ComponentFixture<AuctionsBidsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuctionsBidsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuctionsBidsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
