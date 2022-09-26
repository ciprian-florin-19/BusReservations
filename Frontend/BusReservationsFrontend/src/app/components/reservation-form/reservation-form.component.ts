import { DatePipe } from '@angular/common';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { BusDrivenRoute } from 'src/app/models/busDrivenRoute';
import { Reservation } from 'src/app/models/reservation';
import { User } from 'src/app/models/user';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { UserServiceService } from 'src/app/services/user-service.service';

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

  user?: User;
  @Input()
  autofilledData!: {
    bdrId: string;
    seatNumber: number;
  };
  routeData = new BehaviorSubject<BusDrivenRoute | null>(null);
  constructor(
    private bdr: BusDrivenRoutesService,
    private datePipe: DatePipe,
    private userService: UserServiceService,
    private reservationService: ReservationService
  ) {}

  ngOnInit(): void {
    this.bdr
      .getBusDrivenRouteById(this.autofilledData?.bdrId)
      .subscribe((r) => {
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
      seatType: '1',
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
        user = u;
        console.log('found');
        this.createReservation(user);
      },
      error: (error) => {
        this.userService.addUser(user).subscribe((u) => {
          user = u;
          console.log(`added user ${u.name}`);
          this.createReservation(user);
        });
      },
      complete: () => {
        console.log('completed');
      },
    });
  }
  createReservation(user: User) {
    let reservation: Reservation = {
      busDrivenRouteId: this.autofilledData.bdrId,
      userId: user.id,
      seatDto: {
        seatNumber: this.busSchema.selectedSeat,
        status: Number(this.routeForm.controls.seatType.value),
      },
    };
    console.log(reservation);
    console.log(user);
    this.reservationService.addReservation(reservation).subscribe((r) => {
      console.log(r);
    });
  }
}
