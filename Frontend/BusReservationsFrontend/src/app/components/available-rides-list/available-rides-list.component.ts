import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';

@Component({
  selector: 'app-available-rides-list',
  templateUrl: './available-rides-list.component.html',
  styleUrls: ['./available-rides-list.component.css'],
})
export class AvailableRidesListComponent implements OnInit {
  @ViewChild('rides')
  rides?: any;
  constructor(
    private bdr: BusDrivenRoutesService,
    private datePipe: DatePipe,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    let queryParams = this.activatedRoute.snapshot.queryParamMap;
    let queryParamsObject = {
      start: queryParams.get('start'),
      destination: queryParams.get('destination'),
      year: queryParams.get('year'),
      month: queryParams.get('month'),
      day: queryParams.get('day'),
    };
    console.log(queryParamsObject);

    this.bdr
      .getAvailableRides(
        queryParamsObject.start,
        queryParamsObject.destination,
        queryParamsObject.day,
        queryParamsObject.month,
        queryParamsObject.year
      )
      .subscribe({
        next: (r) => {
          this.rides.result = r;
          this.rides.isLoading = false;
          this.rides.result.currentPage = r.paginationParameters.currentPage--;
          this.rides.elementCount = r.paginationParameters.pageSize;
        },
        error: (e) => {
          this.rides.isLoading = false;
          this.rides.isEmpty = true;
          console.log(e);
        },
      });
  }
  onPageChange(event: any) {
    window.scroll(0, 0);
    this.bdr.getAll(event.pageIndex + 1).subscribe((r) => {
      this.rides.result = r;
      this.rides.isLoading = false;
      this.rides.result.currentPage--;
      this.rides.elementCount =
        r.paginationParameters.pageCount * r.paginationParameters.pageSize;
    });
  }
}
