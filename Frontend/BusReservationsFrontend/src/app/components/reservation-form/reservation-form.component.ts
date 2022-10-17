import { DatePipe } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import html2canvas from 'html2canvas';
import jspdf from 'jspdf';
import jsPDF from 'jspdf';
import { BehaviorSubject, Observable } from 'rxjs';
import { ComponentCanActivate } from 'src/app/guards/direct-link-input.guard';
import { BusDrivenRoute } from 'src/app/models/busDrivenRoute';
import { ReservationGetDto } from 'src/app/models/reservationGetDto';
import { ReservationPutPostDto } from 'src/app/models/reservationPutPostDto';
import { Seat } from 'src/app/models/seat';
import { User } from 'src/app/models/user';
import { UserStates } from 'src/app/models/userStates';
import { AccountService } from 'src/app/services/account.service';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { UserServiceService } from 'src/app/services/user-service.service';
import { TicketComponent } from '../ticket/ticket.component';

@Component({
  selector: 'app-reservation-form',
  templateUrl: './reservation-form.component.html',
  styleUrls: ['./reservation-form.component.css'],
})
export class ReservationFormComponent implements OnInit, ComponentCanActivate {
  routeForm = new FormGroup({
    date: new FormControl(''),
    departureTime: new FormControl(''),
    arrivalTime: new FormControl(''),
    departure: new FormControl(''),
    destination: new FormControl(''),
    bus: new FormControl(''),
    seatType: new FormControl(''),
  });

  userForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    phone: new FormControl(''),
    email: new FormControl(''),
  });

  @ViewChild('schema')
  busSchema: any;
  @Input()
  autofilledData: {
    bdrId: string;
    seatNumber?: number;
  } = {
    bdrId: '',
    seatNumber: -1,
  };
  @ViewChild('ticket')
  ticket?: ElementRef;
  routeData = new BehaviorSubject<BusDrivenRoute | null>(null);
  user!: User;
  createdReservation!: ReservationGetDto;
  ticketDetails?: ReservationGetDto;
  isLoggedIn?: boolean;
  constructor(
    private bdr: BusDrivenRoutesService,
    private datePipe: DatePipe,
    private userService: UserServiceService,
    private reservationService: ReservationService,
    private router: Router,
    private tokenStorage: TokenStorageService,
    private accountService: AccountService
  ) {
    tokenStorage.exists.subscribe((r) => {
      this.isLoggedIn = r;
      console.log(r);
    });
  }
  canActivate(permissions: UserStates): boolean | Observable<boolean> {
    return true;
  }

  ngOnInit(): void {
    this.bdr.getBusDrivenRouteById(this.autofilledData.bdrId).subscribe((r) => {
      this.routeData.next(r);
      this.autofillFormValues(r);
      if (this.isLoggedIn) this.autofillUserData();
      console.log(this.autofilledData);
    });
  }

  autofillFormValues(routeData: any): void {
    this.routeForm.setValue({
      date: this.datePipe.transform(
        routeData.drivenRoute.timeTable.departureDate,
        'dd/MM/yyyy'
      ),
      departureTime: this.datePipe.transform(
        routeData.drivenRoute.timeTable.departureDate,
        'hh:mm'
      ),
      arrivalTime: this.datePipe.transform(
        routeData.drivenRoute.timeTable.arivvalDate,
        'hh:mm'
      ),
      departure: routeData.drivenRoute.start,
      destination: routeData.drivenRoute.destination,
      bus: routeData.bus.name,
      seatType: '0',
    });
  }

  autofillUserData() {
    var userData: any;
    var accountId = this.tokenStorage.getSession().accountId;
    this.accountService.getAccountById(accountId).subscribe({
      next: (a) => {
        var fullName = a.user.fullName.split(' ');
        userData = {
          email: a.user.email,
          firstName: fullName[0],
          lastName: fullName[1],
          phone: a.user.phoneNumber,
        };
        this.userForm.setValue(userData);
      },
      error: (e) => {
        console.log(e);
      },
    });
  }

  onSubmit() {
    let userFormData = this.userForm.value;
    let user: User = {
      id: '',
      fullName: `${userFormData.firstName} ${userFormData.lastName}`,
      email: `${userFormData.email}`,
      phoneNumber: `${userFormData.phone}`,
    };
    this.userService.getExistingUser(user).subscribe({
      next: (u) => {
        this.router
          .navigateByUrl('/routes/reservation-form/complete')
          .then((nav) => {
            user = u;
            console.log('found');
            this.createReservation(user);
            window.scroll(0, 0);
          });
      },
      error: (error) => {
        this.userService.addUser(user).subscribe((u) => {
          this.router
            .navigateByUrl('/routes/reservation-form/complete')
            .then((nav) => {
              user = u;
              console.log(`added user ${u.fullName}`);
              this.createReservation(user);
              window.scroll(0, 0);
            });
        });
      },
      complete: () => {
        console.log('completed');
      },
    });
  }
  createReservation(user: User) {
    let reservation: ReservationPutPostDto = {
      id: '',
      busDrivenRouteId: this.autofilledData.bdrId,
      userId: user.id,
      seatDto: {
        seatNumber: this.busSchema.selectedSeat,
        status: Number(this.routeForm.controls.seatType.value),
      },
    };
    this.reservationService.addReservation(reservation).subscribe((r) => {
      this.createdReservation = r;
      this.downloadAsPdf();
      console.log(r);
    });
  }
  getTicketDetails() {
    if (this.routeData.value != undefined) {
      let seat = new Seat(
        Number(`${this.busSchema.selectedSeat}`),
        Number(`${this.routeForm.controls.seatType.value}`)
      );
      let finalSeatPrice;
      if (seat.discount != undefined)
        finalSeatPrice =
          this.routeData.value.drivenRoute.seatPrice -
          (this.routeData.value.drivenRoute.seatPrice / 100) * seat.discount;
      this.ticketDetails = {
        id: '',
        busDrivenRoute: this.routeData.value,
        user: {
          id: '',
          fullName: `${this.userForm.controls.firstName.value} ${this.userForm.controls.lastName.value}`,
          phoneNumber: `${this.userForm.controls.phone.value}`,
          email: `${this.userForm.controls.email.value}`,
        },
        seat: seat,
        finalSeatPrice: Number(`${finalSeatPrice}`),
      };
    }
  }
  onChange(event: any) {
    if (event.selectedIndex == 2) {
      this.getTicketDetails();
      console.log(this.ticketDetails);
      if (this.ticketDetails != undefined)
        this.createdReservation = this.ticketDetails;
    }
  }
  downloadAsPdf() {
    this.reservationService
      .getReservationInvoice(this.createdReservation.id)
      .subscribe({
        next: (r) => {
          const byteArray = new Uint8Array(
            atob(r)
              .split('')
              .map((char) => char.charCodeAt(0))
          );
          const blob = new Blob([byteArray], { type: 'application/pdf' });
          const link = document.createElement('a');

          link.href = URL.createObjectURL(blob);
          link.download = 'bilet';

          document.body.append(link);
          link.click();
          link.remove();
        },
        error: (e) => {
          console.log(e);
        },
      });
  }
  ngAfterViewInit() {
    console.log(document.getElementById('ticket'));
  }
}
