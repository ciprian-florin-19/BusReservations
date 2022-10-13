import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonComponent } from './components/button/button.component';
import { TableComponent } from './components/table/table.component';
import { ContainerComponent } from './components/container/container.component';
import { ToUpperPipe } from './pipes/to-upper.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { FooterComponent } from './components/footer/footer.component';
import { SearchBarComponent } from './components/search-bar/search-bar.component';
import { RouterModule } from '@angular/router';
import { HomeViewComponent } from './home-view/home-view.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BusDrivenRoutesViewComponent } from './components/bus-driven-routes-view/bus-driven-routes-view.component';
import { BusSchemaComponent } from './components/bus-schema/bus-schema.component';
import { AddReservationViewComponent } from './components/add-reservation-view/add-reservation-view.component';
import { CommonModule, DatePipe } from '@angular/common';
import {
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
} from '@angular/material-moment-adapter';
import { DateAdapter } from '@angular/material/core';
import 'moment/locale/ro';
import { RidesListComponent } from './components/rides-list/rides-list.component';
import { DateFilterComponent } from './components/date-filter/date-filter.component';
import { AvailableRidesListComponent } from './components/available-rides-list/available-rides-list.component';
import { ReservationFormComponent } from './components/reservation-form/reservation-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TicketComponent } from './components/ticket/ticket.component';
import { BookingCompleteViewComponent } from './components/booking-complete-view/booking-complete-view.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { AuthInterceptor } from './auth.interceptor';
import { MessageComponent } from './components/message/message.component';
import { UserTicketsViewComponent } from './components/user-tickets-view/user-tickets-view.component';
import { TicketDetailsComponent } from './components/ticket-details/ticket-details.component';
import { ProfileComponent } from './components/profile/profile.component';
import { TicketsListComponent } from './components/tickets-list/tickets-list.component';
import { ProfileEditorComponent } from './components/profile-editor/profile-editor.component';
import { ConfirmationComponent } from './components/confirmation/confirmation.component';
import { ChangesPromptGuard } from './guards/changes-prompt.guard';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { RawDataEditorComponent } from './components/raw-data-editor/raw-data-editor.component';
import { BusEditorComponent } from './components/bus-editor/bus-editor.component';
import { BdrEditorComponent } from './components/bdr-editor/bdr-editor.component';
import { DrivenRouteEditorComponent } from './components/driven-route-editor/driven-route-editor.component';
import { BusDialogComponent } from './components/bus-dialog/bus-dialog.component';
import { RouteDialogComponent } from './components/route-dialog/route-dialog.component';
import { BdrDialogComponent } from './components/bdr-dialog/bdr-dialog.component';
import { MatSelectScrollBottomDirective } from './mat-select-scroll-bottom.directive';
import { MaterialModule } from './material/material.module';

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
    ConfirmationComponent,
    AdminPanelComponent,
    RawDataEditorComponent,
    BusEditorComponent,
    BdrEditorComponent,
    DrivenRouteEditorComponent,
    BusDialogComponent,
    RouteDialogComponent,
    BdrDialogComponent,
    MatSelectScrollBottomDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule,
    MaterialModule,
  ],
  providers: [
    DatePipe,
    { provide: MAT_DATE_LOCALE, useValue: 'ro-RO' },
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    ChangesPromptGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
