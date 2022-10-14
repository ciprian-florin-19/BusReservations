import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { TicketComponent } from './ticket/ticket.component';
import { MaterialModule } from '../material/material.module';
import { AppComponent } from '../app.component';
import { HomeViewComponent } from '../home-view/home-view.component';
import { MatSelectScrollBottomDirective } from '../mat-select-scroll-bottom.directive';
import { ToUpperPipe } from '../pipes/to-upper.pipe';
import { AddReservationViewComponent } from './add-reservation-view/add-reservation-view.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { AvailableRidesListComponent } from './available-rides-list/available-rides-list.component';
import { BdrDialogComponent } from './bdr-dialog/bdr-dialog.component';
import { BdrEditorComponent } from './bdr-editor/bdr-editor.component';
import { BookingCompleteViewComponent } from './booking-complete-view/booking-complete-view.component';
import { BusDialogComponent } from './bus-dialog/bus-dialog.component';
import { BusDrivenRoutesViewComponent } from './bus-driven-routes-view/bus-driven-routes-view.component';
import { BusEditorComponent } from './bus-editor/bus-editor.component';
import { BusSchemaComponent } from './bus-schema/bus-schema.component';
import { ButtonComponent } from './button/button.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { ContainerComponent } from './container/container.component';
import { DateFilterComponent } from './date-filter/date-filter.component';
import { DrivenRouteEditorComponent } from './driven-route-editor/driven-route-editor.component';
import { FooterComponent } from './footer/footer.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { MessageComponent } from './message/message.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileEditorComponent } from './profile-editor/profile-editor.component';
import { ProfileComponent } from './profile/profile.component';
import { RawDataEditorComponent } from './raw-data-editor/raw-data-editor.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { ReservationFormComponent } from './reservation-form/reservation-form.component';
import { RidesListComponent } from './rides-list/rides-list.component';
import { RouteDialogComponent } from './route-dialog/route-dialog.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { SearchResultsComponent } from './search-results/search-results.component';
import { TableComponent } from './table/table.component';
import { TicketDetailsComponent } from './ticket-details/ticket-details.component';
import { TicketsListComponent } from './tickets-list/tickets-list.component';
import { UserTicketsViewComponent } from './user-tickets-view/user-tickets-view.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from '../app-routing.module';
import {
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
  MAT_MOMENT_DATE_FORMATS,
} from '@angular/material-moment-adapter';
import { MAT_DATE_LOCALE, DateAdapter } from '@angular/material/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';
import { AuthInterceptor } from '../auth.interceptor';
import { ChangesPromptGuard } from '../guards/changes-prompt.guard';
import { MAT_DATE_FORMATS } from '../MAT_DATE_FORMATS';
import { DirectLinkInputGuard } from '../guards/direct-link-input.guard';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
  declarations: [
    TicketComponent,
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
    NotFoundComponent,
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
  exports: [
    TicketComponent,
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
  providers: [
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
    { provide: MAT_DIALOG_DATA, useValue: {} },
    ChangesPromptGuard,
    DirectLinkInputGuard,
  ],
})
export class ComponentsModule {}
