import { Component, OnInit } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css'],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'ro-RO' }],
})
export class SearchBarComponent implements OnInit {
  constructor(private dateAdapter: DateAdapter<any>) {
    dateAdapter.setLocale('ro');
  }

  ngOnInit(): void {}
}
