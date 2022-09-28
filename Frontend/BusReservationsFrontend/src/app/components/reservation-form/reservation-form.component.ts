import { DatePipe } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import html2canvas from 'html2canvas';
import jspdf from 'jspdf';
import jsPDF from 'jspdf';
import { BehaviorSubject, Observable } from 'rxjs';
import { BusDrivenRoute } from 'src/app/models/busDrivenRoute';
import { ReservationGetDto } from 'src/app/models/reservationGetDto';
import { ReservationPutPostDto } from 'src/app/models/reservationPutPostDto';
import { Seat } from 'src/app/models/seat';
import { User } from 'src/app/models/user';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { UserServiceService } from 'src/app/services/user-service.service';
import { TicketComponent } from '../ticket/ticket.component';

@Component({
  selector: 'app-reservation-form',
  templateUrl: './reservation-form.component.html',
  styleUrls: ['./reservation-form.component.css'],
})
export class ReservationFormComponent implements OnInit {
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

  constructor(
    private bdr: BusDrivenRoutesService,
    private datePipe: DatePipe,
    private userService: UserServiceService,
    private reservationService: ReservationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.bdr.getBusDrivenRouteById(this.autofilledData.bdrId).subscribe((r) => {
      this.routeData.next(r);
      this.autofillFormValues(r);

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
  onSubmit() {
    let userFormData = this.userForm.value;
    let user: User = {
      id: '',
      name: `${userFormData.firstName} ${userFormData.lastName}`,
      email: `${userFormData.email}`,
      phone: `${userFormData.phone}`,
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
              console.log(`added user ${u.name}`);
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
      console.log(r);
    });
    this.downloadAsPdf();
  }
  getTicketDetails(): ReservationGetDto | undefined {
    if (this.routeData.value != undefined) {
      let seat = new Seat(
        Number(`${this.autofilledData.seatNumber}`),
        Number(`${this.routeForm.controls.seatType.value}`)
      );
      let finalSeatPrice;
      if (seat.discount != undefined)
        finalSeatPrice =
          this.routeData.value.drivenRoute.seatPrice -
          (this.routeData.value.drivenRoute.seatPrice / 100) * seat.discount;
      return {
        bus: this.routeData.value.bus,
        drivenRoute: this.routeData.value.drivenRoute,
        user: {
          id: '',
          name: `${this.userForm.controls.firstName.value} ${this.userForm.controls.lastName.value}`,
          phone: `${this.userForm.controls.phone.value}`,
          email: `${this.userForm.controls.email.value}`,
        },
        seat: seat,
        finalSeatPrice: Number(`${finalSeatPrice}`),
      };
    }
    return undefined;
  }
  onChange(event: any) {
    if (event.selectedIndex == 2) {
      let details = this.getTicketDetails();
      if (details != undefined) this.createdReservation = details;
    }
  }
  downloadAsPdf() {
    let ticket = document.getElementById('ticket');
    if (ticket != undefined)
      html2canvas(ticket, { backgroundColor: '#000000' }).then((canvas) => {
        const contentDataURL = canvas.toDataURL('image/png');
        let pdf = new jspdf('landscape', 'mm', 'a5');
        const imgProps = pdf.getImageProperties(contentDataURL);
        let imgWidth = pdf.internal.pageSize.getWidth();
        let imgHeight = (imgProps.height * imgWidth) / imgProps.width;
        let position = 0;
        pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight);
        pdf.save('bilet.pdf');
      });
  }
  ngAfterViewInit() {
    console.log(document.getElementById('ticket'));
  }
}
