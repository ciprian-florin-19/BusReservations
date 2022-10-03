import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddReservationViewComponent } from './components/add-reservation-view/add-reservation-view.component';
import { AvailableRidesListComponent } from './components/available-rides-list/available-rides-list.component';
import { BookingCompleteViewComponent } from './components/booking-complete-view/booking-complete-view.component';
import { BusDrivenRoutesViewComponent } from './components/bus-driven-routes-view/bus-driven-routes-view.component';
import { ProfileComponent } from './components/profile/profile.component';
import { RidesListComponent } from './components/rides-list/rides-list.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { TicketDetailsComponent } from './components/ticket-details/ticket-details.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { UserTicketsViewComponent } from './components/user-tickets-view/user-tickets-view.component';
import { HomeViewComponent } from './home-view/home-view.component';

const routes: Routes = [
  { path: 'home', component: HomeViewComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'search', component: AvailableRidesListComponent },
  { path: 'routes', component: RidesListComponent },
  { path: 'routes/reservation-form', component: AddReservationViewComponent },
  {
    path: 'routes/reservation-form/complete',
    component: BookingCompleteViewComponent,
  },
  {
    path: 'user/reservations',
    component: UserTicketsViewComponent,
  },
  {
    path: 'user/reservations/ticket-details',
    component: TicketDetailsComponent,
  },
  { path: 'user/profile', component: ProfileComponent },
  {
    path: 'user/profile/ticket-details',
    component: TicketDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
