import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { BusDrivenRoutesViewComponent } from '../bus-driven-routes-view/bus-driven-routes-view.component';

@Component({
  selector: 'app-rides-list',
  templateUrl: './rides-list.component.html',
  styleUrls: ['./rides-list.component.css'],
})
export class RidesListComponent implements OnInit {
  @ViewChild('rides')
  rides!: BusDrivenRoutesViewComponent;
  constructor(
    private bdr: BusDrivenRoutesService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.bdr.getAll().subscribe({
      next: (r) => {
        --r.paginationParameters.currentPage;
        this.rides.result = r;
        this.rides.isLoading = false;
        console.log(r);
      },
      error: (e) => {
        this.rides.isLoading = false;
        this.rides.isEmpty = true;
      },
    });
  }
  onPageChange(event: any) {
    window.scroll(0, 0);
    let nextPageIndex = event.pageIndex + 1;
    if (this.rides.isFiltered) {
      event.pageIndex = 0;
      this.filterResults(this.rides.dateFilter, nextPageIndex);
    } else
      this.bdr.getAll(nextPageIndex).subscribe((r) => {
        --r.paginationParameters.currentPage;
        this.rides.result = r;
        this.rides.isLoading = false;
        console.log(this.rides.result);
      });
  }

  filterResults(departureDate: Date, index: number = 1): void {
    let date = this.formatDate(departureDate);
    this.rides.isFiltered = true;
    this.rides.dateFilter = departureDate;
    this.bdr
      .getAllByDate(date.day, date.month, date.year, index)
      .subscribe((r) => {
        r.paginationParameters.currentPage--;
        this.rides.result = r;
        this.rides.isLoading = false;
        console.log(r);
      });
  }

  formatDate(date: Date): {
    day: string | null;
    month: string | null;
    year: string | null;
  } {
    let day: string | null = this.datePipe.transform(date, 'dd');
    let month: string | null = this.datePipe.transform(date, 'MM');
    let year: string | null = this.datePipe.transform(date, 'yyyy');

    console.log(day, month, year);
    return {
      day: day,
      month: month,
      year: year,
    };
  }
}
