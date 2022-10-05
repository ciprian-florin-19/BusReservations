import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BusService } from 'src/app/services/bus.service';
import { MessageComponent } from '../message/message.component';

@Component({
  selector: 'app-bus-dialog',
  templateUrl: './bus-dialog.component.html',
  styleUrls: ['./bus-dialog.component.css'],
})
export class BusDialogComponent implements OnInit {
  isLoading: boolean = false;
  @ViewChild('busData')
  form?: NgForm;
  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: {
      message: string;
      okMessage: string;
      cancelMessage: string;
      action: string;
      busId: string;
    },
    private service: BusService,
    private snackbar: MatSnackBar
  ) {}

  ngOnInit(): void {
    if (this.data.action == 'edit') {
      this.service.getBusById(this.data.busId).subscribe({
        next: (b) => {
          console.log(b);

          this.form?.setValue({
            name: b.name,
            capacity: b.capacity,
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

    if (this.data.action == 'edit') this.updateBus(userInput);
    else this.addBus(userInput);
  }
  updateBus(userInput: NgForm) {
    this.service.updateBus(this.data.busId, userInput.value).subscribe({
      next: () => {
        this.showMessage('Modificarile au fost salvate', '');
      },
      error: (e) => {
        this.showMessage('Modificarile nu au fost salvate', '');
        console.log(e);
      },
    });
  }
  addBus(userInput: NgForm) {
    this.service.addBus(this.data.busId, userInput.value).subscribe({
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
