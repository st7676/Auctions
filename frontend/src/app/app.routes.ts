import { Routes } from '@angular/router';
import { AllAuctionsComponent } from './components/all-auctions/all-auctions.component';
import { AuctionsBidsComponent } from './components/auctions-bids/auctions-bids.component';
export const routes: Routes = [
    { path: '', component: AllAuctionsComponent },
    { path: 'auction/:id', component: AuctionsBidsComponent }

];
