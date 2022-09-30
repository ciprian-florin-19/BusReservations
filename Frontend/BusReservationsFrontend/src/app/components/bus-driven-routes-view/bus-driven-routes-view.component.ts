import { DatePipe } from '@angular/common';
import {
  Component,
  ElementRef,
  EventEmitter,
  OnChanges,
  OnDestroy,
  OnInit,
  Output,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import { Router } from '@angular/router';
import { BusDrivenRoute } from 'src/app/models/busDrivenRoute';
import { PagedList } from 'src/app/models/PagedList';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { RouteDetailsService } from 'src/app/services/route-details.service';
import { BusSchemaComponent } from '../bus-schema/bus-schema.component';

@Component({
  selector: 'app-bus-driven-routes-view',
  templateUrl: './bus-driven-routes-view.component.html',
  styleUrls: ['./bus-driven-routes-view.component.css'],
})
export class BusDrivenRoutesViewComponent implements OnInit {
  result?: PagedList<BusDrivenRoute>;
  isFiltered: boolean = false;
  dateFilter: Date = new Date();
  elementCount: number = 0;
  isLoading: boolean = true;
  @Output()
  onPageChangeEvent: EventEmitter<any> = new EventEmitter<any>();

  @Output()
  filterResultsEvent: EventEmitter<{ departureDate: Date; index: number }> =
    new EventEmitter();

  @ViewChild('schema')
  busSchema?: BusSchemaComponent;
  constructor(private routeDetails: RouteDetailsService) {}
  ngOnInit(): void {}

  onPageChange(event: any) {
    console.log(this.result);
    console.log(this.elementCount);

    this.onPageChangeEvent.emit(event);
  }
  filterResults(date: Date, index: number = 1) {
    this.filterResultsEvent.emit({ departureDate: date, index: index });
  }
  sendRouteDetails(id: string, seat?: number) {
    this.routeDetails.setDetails({
      bdrId: id,
      selectedSeat: seat,
    });
  }
}
