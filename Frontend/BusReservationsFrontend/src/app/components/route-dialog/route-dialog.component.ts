import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { DrivenRoute } from 'src/app/models/drivenRoute';
import { DrivenRouteService } from 'src/app/services/driven-route.service';
import { MessageComponent } from '../message/message.component';
import { UserTicketsViewComponent } from '../user-tickets-view/user-tickets-view.component';

@Component({
  selector: 'app-route-dialog',
  templateUrl: './route-dialog.component.html',
  styleUrls: ['./route-dialog.component.css'],
})
export class RouteDialogComponent implements OnInit {
  isLoading: boolean = false;
  @ViewChild('routeData')
  form?: NgForm;
  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: {
      message: string;
      okMessage: string;
      cancelMessage: string;
      action: string;
      routeId: string;
    },
    private service: DrivenRouteService,
    private snackbar: MatSnackBar,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    if (this.data.action == 'edit') {
      this.service.getRouteById(this.data.routeId).subscribe({
        next: (b) => {
          console.log(b);

          this.form?.setValue({
            start: b.start,
            destination: b.destination,
            date: b.timeTable.departureDate,
            departureHour: this.datePipe.transform(
              b.timeTable.departureDate,
              'HH'
            ),
            departureMinute: this.datePipe.transform(
              b.timeTable.departureDate,
              'mm'
            ),
            hour: b.timeTable.duration.substring(0, 2),
            minute: b.timeTable.duration.substring(3, 5),
            price: b.seatPrice,
          });
        },
        error: (e) => {
          console.log(e);
        },
      });
    }
  }

  onSubmit(userInput: NgForm) {
    if (!userInput.dirty) return;
    if (this.data.action == 'edit') this.updateRoute(userInput);
    else this.addRoute(userInput);
  }
  updateRoute(userInput: NgForm) {
    const routeData = this.formatUserInput(userInput);
    this.service.updateDrivenRoute(this.data.routeId, routeData).subscribe({
      next: () => {
        this.showMessage('Modificarile au fost salvate', '');
      },
      error: (e) => {
        this.showMessage('Modificarile nu au fost salvate', '');
        console.log(e);
      },
    });
  }
  addRoute(userInput: NgForm) {
    const routeData = this.formatUserInput(userInput);
    this.service.addDrivenRoute(routeData).subscribe({
      next: () => {
        this.showMessage('Ruta a fost adaugata cu succes', '');
      },
      error: (e) => {
        this.showMessage('Ruta nu a putut fi adaugata', '');
        console.log(e);
      },
    });
  }

  private showMessage(message: string, name: string) {
    this.snackbar.openFromComponent(MessageComponent, {
      duration: 2000,
      data: {
        message: message,
        name: name,
      },
    });
  }

  formatUserInput(userInput: NgForm) {
    const routeData = userInput.value;
    console.log(routeData);

    let departureTime = moment(
      new Date(
        2022,
        12,
        0,
        routeData.departureHour,
        routeData.departureMinute
      ).getTime()
    ).format('HH:mm');
    console.log(departureTime);

    let departureDate = new Date(
      this.datePipe.transform(routeData.date, 'yyyy-MM-dd') +
        'T' +
        departureTime
    );
    let duration = moment(
      new Date(2022, 12, 0, routeData.hour, routeData.minute).getTime()
    ).format('HH:mm');

    let arrivalDate = moment(departureDate)
      .add(routeData.hour, 'hour')
      .add(routeData.minute, 'minute')
      .toDate();
    let formattedData: DrivenRoute = {
      id: '',
      destination: routeData.destination,
      start: routeData.start,
      seatPrice: routeData.price,
      timeTable: {
        departureDate: departureDate,
        duration: duration,
        arivvalDate: arrivalDate,
      },
    };
    return formattedData;
  }
}
