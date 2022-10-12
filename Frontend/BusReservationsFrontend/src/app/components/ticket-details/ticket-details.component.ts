import { Component, OnInit } from '@angular/core';
import html2canvas from 'html2canvas';
import jspdf from 'jspdf';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-ticket-details',
  templateUrl: './ticket-details.component.html',
  styleUrls: ['./ticket-details.component.css'],
})
export class TicketDetailsComponent implements OnInit {
  constructor(private reservationService: ReservationService) {}

  ngOnInit(): void {}

  downloadAsPdf(id: string) {
    this.reservationService.getReservationInvoice(id).subscribe({
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
}
