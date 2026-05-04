import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-auctions',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './all-auctions.component.html',
  styleUrl: './all-auctions.component.css'
})
export class AllAuctionsComponent implements OnInit {

  auctions: any[] = [];

  constructor(private api: ApiService, private router: Router) {}

  ngOnInit(): void {
    this.api.getAuctions().subscribe(data => {
      this.auctions = data;
    });
  }

  openAuction(a: any) {
    this.router.navigate(['/auction', a.id]);
  }
}