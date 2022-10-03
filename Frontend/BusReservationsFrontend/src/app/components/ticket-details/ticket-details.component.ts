import { Component, OnInit } from '@angular/core';
import html2canvas from 'html2canvas';
import jspdf from 'jspdf';

@Component({
  selector: 'app-ticket-details',
  templateUrl: './ticket-details.component.html',
  styleUrls: ['./ticket-details.component.css'],
})
export class TicketDetailsComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

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
}
