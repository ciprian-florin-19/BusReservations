import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonComponent } from './components/button/button.component';
import { TableComponent } from './components/table/table.component';
import { ContainerComponent } from './components/container/container.component';
import { ToUpperPipe } from './pipes/to-upper.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import {
  MatRippleModule,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
} from '@angular/material/core';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FooterComponent } from './components/footer/footer.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { MatSelectModule } from '@angular/material/select';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { RouterModule } from '@angular/router';
import { HomeViewComponent } from './home-view/home-view.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BusDrivenRoutesViewComponent } from './components/bus-driven-routes-view/bus-driven-routes-view.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BusSchemaComponent } from './components/bus-schema/bus-schema.component';
import { AddReservationViewComponent } from './components/add-reservation-view/add-reservation-view.component';
import { CommonModule, DatePipe } from '@angular/common';
import { MatPaginatorModule } from '@angular/material/paginator';
import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
} from '@angular/material-moment-adapter';
import { DateAdapter } from '@angular/material/core';
import 'moment/locale/ro';
import { RidesListComponent } from './components/rides-list/rides-list.component';
import { DateFilterComponent } from './components/date-filter/date-filter.component';
import { AvailableRidesListComponent } from './components/available-rides-list/available-rides-list.component';
import { ReservationFormComponent } from './components/reservation-form/reservation-form.component';
import { MatStepperModule } from '@angular/material/stepper';
import { ReactiveFormsModule } from '@angular/forms';
import { TicketComponent } from './components/ticket/ticket.component';
import { BookingCompleteViewComponent } from './components/booking-complete-view/booking-complete-view.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { MatDialogModule } from '@angular/material/dialog';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { HttpInterceptor } from '@angular/common/http';
import { AuthInterceptor } from './auth.interceptor';
import { MessageComponent } from './components/message/message.component';
import {
  MatSnackBarModule,
  MAT_SNACK_BAR_DATA,
} from '@angular/material/snack-bar';
import { UserTicketsViewComponent } from './components/user-tickets-view/user-tickets-view.component';
import { MatDividerModule } from '@angular/material/divider';
import { TicketDetailsComponent } from './components/ticket-details/ticket-details.component';
import { ProfileComponent } from './components/profile/profile.component';
import { MatTabsModule } from '@angular/material/tabs';
import { TicketsListComponent } from './components/tickets-list/tickets-list.component';
import { ProfileEditorComponent } from './components/profile-editor/profile-editor.component';

//TO DO clean up
@NgModule({
  declarations: [
    AppComponent,
    ButtonComponent,
    TableComponent,
    ContainerComponent,
    ToUpperPipe,
    NavbarComponent,
    FooterComponent,
    SearchBarComponent,
    HomeViewComponent,
    SearchResultsComponent,
    BusDrivenRoutesViewComponent,
    BusSchemaComponent,
    AddReservationViewComponent,
    RidesListComponent,
    DateFilterComponent,
    AvailableRidesListComponent,
    ReservationFormComponent,
    TicketComponent,
    BookingCompleteViewComponent,
    LoginFormComponent,
    RegisterFormComponent,
    MessageComponent,
    UserTicketsViewComponent,
    TicketDetailsComponent,
    ProfileComponent,
    TicketsListComponent,
    ProfileEditorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    FlexLayoutModule,
    MatRippleModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatSidenavModule,
    MatSelectModule,
    MatAutocompleteModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    CommonModule,
    MatPaginatorModule,
    MatStepperModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatSnackBarModule,
    MatDividerModule,
    MatTabsModule,
  ],
  providers: [
    MatNativeDateModule,
    MatExpansionModule,
    DatePipe,
    { provide: MAT_DATE_LOCALE, useValue: 'ro-RO' },
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: MAT_SNACK_BAR_DATA, useValue: {} },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
