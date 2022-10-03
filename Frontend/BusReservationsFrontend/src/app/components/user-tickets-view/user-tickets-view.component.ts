import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { PagedList } from 'src/app/models/PagedList';
import { ReservationGetDto } from 'src/app/models/reservationGetDto';
import { ReservationSimpleGetDto } from 'src/app/models/reservationSimpleGetDto';
import { User } from 'src/app/models/user';
import { AccountService } from 'src/app/services/account.service';
import { RouteDetailsService } from 'src/app/services/route-details.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { UserServiceService } from 'src/app/services/user-service.service';
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
    public details: RouteDetailsService
  ) {}
  isLoading: boolean = true;
  reservations!: PagedList<ReservationSimpleGetDto>;
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

  sendDetails(reservation: ReservationSimpleGetDto) {
    const details: ReservationGetDto = {
      drivenRoute: reservation.busDrivenRoute,
      user: this.user,
      seat: reservation.seat,
      finalSeatPrice: reservation.finalSeatPrice,
    };
    this.details.setDetails(details);
  }
}
