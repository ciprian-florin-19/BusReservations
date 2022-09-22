import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddReservationViewComponent } from './components/add-reservation-view/add-reservation-view.component';
import { BusDrivenRoutesViewComponent } from './components/bus-driven-routes-view/bus-driven-routes-view.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { HomeViewComponent } from './home-view/home-view.component';

const routes: Routes = [
  { path: 'home', component: HomeViewComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'search', component: SearchResultsComponent },
  { path: 'routes', component: BusDrivenRoutesViewComponent },
  { path: 'routes/reservation-form', component: AddReservationViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
