import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DrivenRouteService } from 'src/app/services/driven-route.service';
import { MessageComponent } from '../message/message.component';

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
    private snackbar: MatSnackBar
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
    console.log('submitted');

    if (this.data.action == 'edit') this.updateRoute(userInput);
    else this.addRoute(userInput);
  }
  updateRoute(userInput: NgForm) {
    console.log(userInput.value);
    return;
    this.service
      .updateDrivenRoute(this.data.routeId, userInput.value)
      .subscribe({
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
    this.service.addDrivenRoute(this.data.routeId, userInput.value).subscribe({
      next: () => {
        this.showMessage('Autobuzul a fost adaugat cu succes', '');
      },
      error: (e) => {
        this.showMessage('Autobuzul nu a putut fi adaugat', '');
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
}
