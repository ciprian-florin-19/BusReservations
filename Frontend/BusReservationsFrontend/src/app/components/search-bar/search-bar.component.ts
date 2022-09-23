import { Component, OnInit } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';
import { Router } from '@angular/router';
import { SearchOptionsService } from 'src/app/services/search-options.service';
import { FormsModule } from '@angular/forms';
import { MatAutocomplete } from '@angular/material/autocomplete';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'ro-RO' }],
})
export class SearchBarComponent implements OnInit {
  options?: { start: string[]; destination: string[] };
  startOptions?: string[];
  destinationOptions?: string[];

  constructor(
    private router: Router,
    private searchOptionsService: SearchOptionsService,
    private dateAdapter: DatePipe
  ) {}

  ngOnInit(): void {
    this.options = this.searchOptionsService.getSearchOptions();
    this.startOptions = this.options.start;
    this.destinationOptions = this.options.destination;
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
