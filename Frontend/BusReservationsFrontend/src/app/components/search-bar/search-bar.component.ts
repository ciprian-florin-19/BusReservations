import { Component, OnInit } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { Router } from '@angular/router';
import { SearchOptionsService } from 'src/app/services/search-options.service';
import { FormsModule } from '@angular/forms';
import { MatAutocomplete } from '@angular/material/autocomplete';
import { DatePipe } from '@angular/common';
import * as moment from 'moment';
import { DrivenRoute } from 'src/app/models/drivenRoute';
import { DrivenRouteService } from 'src/app/services/driven-route.service';
@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'ro-RO' }],
})
export class SearchBarComponent implements OnInit {
  options: { start: string; destination: string }[] = [];
  currentPage: number = 1;
  hasNext: boolean = true;
  minDate: Date = moment().add(1, 'day').toDate();

  constructor(
    private router: Router,
    private routeService: DrivenRouteService,
    private dateAdapter: DatePipe
  ) {}

  ngOnInit(): void {
    this.fetchOptions();
  }

  fetchOptions(page: number = 1) {
    if (this.hasNext)
      this.routeService.getDrivenRoutes(page).subscribe({
        next: (r) => {
          for (let item of r.items) {
            this.options.push({
              start: item.start,
              destination: item.destination,
            });
          }
          this.currentPage = r.paginationParameters.currentPage;
          this.hasNext = r.paginationParameters.hasNext;
        },
      });
  }

  formatQueryParams(start: string, destination: string, date: Date) {
    return { start, destination, date };
  }
  searchAvailableRoutes(
    start: string,
    destination: string,
    date: string
  ): void {
    this.router.navigate(['search'], {
      queryParams: {
        start: start,
        destination: destination,
        year: this.dateAdapter.transform(date, 'yyyy'),
        month: this.dateAdapter.transform(date, 'MM'),
        day: this.dateAdapter.transform(date, 'dd'),
      },
    });
  }
}
