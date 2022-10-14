import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddReservationViewComponent } from './components/add-reservation-view/add-reservation-view.component';
import { AvailableRidesListComponent } from './components/available-rides-list/available-rides-list.component';
import { BdrEditorComponent } from './components/bdr-editor/bdr-editor.component';
import { BookingCompleteViewComponent } from './components/booking-complete-view/booking-complete-view.component';
import { BusDrivenRoutesViewComponent } from './components/bus-driven-routes-view/bus-driven-routes-view.component';
import { BusEditorComponent } from './components/bus-editor/bus-editor.component';
import { DrivenRouteEditorComponent } from './components/driven-route-editor/driven-route-editor.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ProfileComponent } from './components/profile/profile.component';
import { RidesListComponent } from './components/rides-list/rides-list.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { TicketDetailsComponent } from './components/ticket-details/ticket-details.component';
import { TicketComponent } from './components/ticket/ticket.component';
import { UserTicketsViewComponent } from './components/user-tickets-view/user-tickets-view.component';
import { ChangesPromptGuard } from './guards/changes-prompt.guard';
import { DirectLinkInputGuard } from './guards/direct-link-input.guard';
import { HomeViewComponent } from './home-view/home-view.component';

const routes: Routes = [
  { path: 'home', component: HomeViewComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'search',
    canActivate: [DirectLinkInputGuard],
    component: AvailableRidesListComponent,
  },
  { path: 'routes', component: RidesListComponent },
  {
    path: 'routes/reservation-form',
    canActivate: [DirectLinkInputGuard],
    component: AddReservationViewComponent,
  },
  {
    path: 'routes/reservation-form/complete',
    canActivate: [DirectLinkInputGuard],
    component: BookingCompleteViewComponent,
  },
  {
    path: 'user/reservations',
    canActivate: [DirectLinkInputGuard],
    component: UserTicketsViewComponent,
  },
  {
    path: 'user/reservations/ticket-details',
    canActivate: [DirectLinkInputGuard],
    component: TicketDetailsComponent,
  },
  {
    path: 'user/profile',
    component: ProfileComponent,
    canActivate: [DirectLinkInputGuard],
    canDeactivate: [ChangesPromptGuard],
    children: [
      {
        path: 'bus-editor',
        canActivate: [DirectLinkInputGuard],
        component: BusEditorComponent,
      },
      {
        path: 'bdr-editor',
        canActivate: [DirectLinkInputGuard],
        component: BdrEditorComponent,
      },
      {
        path: 'route-editor',
        canActivate: [DirectLinkInputGuard],
        component: DrivenRouteEditorComponent,
      },
    ],
  },
  {
    path: 'user/profile/ticket-details',
    canActivate: [DirectLinkInputGuard],
    component: TicketDetailsComponent,
  },
  {
    path: 'not-found',
    component: NotFoundComponent,
  },
  {
    path: '**',
    redirectTo: 'not-found',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
