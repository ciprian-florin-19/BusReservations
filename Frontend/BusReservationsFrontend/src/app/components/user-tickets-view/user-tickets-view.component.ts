import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PagedList } from 'src/app/models/PagedList';
import { ReservationGetDto } from 'src/app/models/reservationGetDto';
import { User } from 'src/app/models/user';
import { AccountService } from 'src/app/services/account.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { RouteDetailsService } from 'src/app/services/route-details.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { UserServiceService } from 'src/app/services/user-service.service';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { MessageComponent } from '../message/message.component';
import { TicketDetailsComponent } from '../ticket-details/ticket-details.component';

@Component({
  selector: 'app-user-tickets-view',
  templateUrl: './user-tickets-view.component.html',
  styleUrls: [
    './user-tickets-view.component.css',
    '../bus-driven-routes-view/bus-driven-routes-view.component.css',
  ],
})
export class UserTicketsViewComponent implements OnInit {
  constructor(
    private userService: UserServiceService,
    private accountService: AccountService,
    private tokenStorage: TokenStorageService,
    public details: RouteDetailsService,
    private reservationService: ReservationService,
    private dialog: MatDialog,
    private snackbar: MatSnackBar
  ) {}
  isLoading: boolean = true;
  isEmpty: boolean = false;
  reservations!: PagedList<ReservationGetDto>;
  user!: User;
  elementCount: number = 0;
  @Input()
  isEmbedded: boolean = false;
  ngOnInit(): void {
    this.accountService
      .getAccountById(this.tokenStorage.getSession().accountId)
      .subscribe({
        next: (a) => {
          console.log(a);
          this.user = a.user;
          this.getUserReservations(a.user.id);
          console.log(this.reservations);
        },
        error: (e) => {
          console.log(e);
        },
      });
  }

  getUserReservations(userId: string, index: number = 1) {
    this.userService.getUserReservations(userId, index).subscribe({
      next: (r) => {
        console.log(r);

        this.reservations = r;
        this.reservations.paginationParameters.currentPage--;
        this.elementCount =
          this.reservations?.paginationParameters?.pageSize *
          this.reservations?.paginationParameters?.pageCount;
      },
      error: (e) => {
        console.log(e);
        this.isLoading = false;
        this.isEmpty = true;

        //TO DO add not found message
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
  onPageChange() {
    this.getUserReservations(
      this.user.id,
      this.reservations.paginationParameters.currentPage++
    );
  }

  sendDetails(reservation: ReservationGetDto) {
    const details: ReservationGetDto = {
      id: reservation.id,
      busDrivenRoute: reservation.busDrivenRoute,
      user: this.user,
      seat: reservation.seat,
      finalSeatPrice: reservation.finalSeatPrice,
    };
    this.details.setDetails(details);
  }

  cancelReservation(id: string) {
    const dialogRef = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Esti sigur ca vrei sa anulezi rezervarea?',
        okMessage: 'Da',
        cancelMessage: 'Nu',
      },
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe({
      next: (r) => {
        if (r)
          this.reservationService.deleteReservation(id).subscribe({
            next: () => {
              this.showMessage('Rezervarea a fost anulata cu sucess', '');
              this.getUserReservations(this.user.id, 1);
            },
            error: (e) => {
              console.log(e);
            },
          });
        else {
          console.log('cancelled');
        }
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
