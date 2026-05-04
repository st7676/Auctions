import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-auctions-bids',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './auctions-bids.component.html',
  styleUrl: './auctions-bids.component.css'
})

export class AuctionsBidsComponent {

auctionId!: number;
  auction: any;
  bids: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private api: ApiService
  ) {}

  bidAmount: number = 0;

  bid() {
    this.api.placeBid(this.auctionId, this.bidAmount).subscribe(() => {
      // this.loadBids();
    });
  }
  
  ngOnInit(): void {
    this.auctionId = Number(this.route.snapshot.paramMap.get('id'));

    // this.loadAuction();
    // this.loadBids();
  }

  // loadAuction() {
  //   this.api.getAuction(this.auctionId).subscribe(data => {
  //     this.auction = data;
  //   });
  // }

  // loadBids() {
  //   this.api.getBidsByAuction(this.auctionId).subscribe(data => {
  //     this.bids = data;
  //   });
  // }
}