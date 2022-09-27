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
    this.bdr
      .getAvailableRides(
        queryParamsObject.start,
        queryParamsObject.destination,
        queryParamsObject.day,
        queryParamsObject.month,
        queryParamsObject.year
      )
      .subscribe((r) => {
        this.rides.result = r;
        this.rides.isLoading = false;
        this.rides.result.currentPage--;
        if (r.pageCount > 1) this.rides.elementCount = r.pageCount * r.pageSize;
        else this.rides.elementCount = r.busDrivenRoutes.length;
      });
  }
  onPageChange(event: any) {
    window.scroll(0, 0);
    this.bdr.getAll(event.pageIndex + 1).subscribe((r) => {
      this.rides.result = r;
      this.rides.isLoading = false;
      this.rides.result.currentPage--;
      this.rides.elementCount = r.pageCount * r.pageSize;
    });
  }
}