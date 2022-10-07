import { Component, Input, OnInit } from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-date-filter',
  templateUrl: './date-filter.component.html',
  styleUrls: ['./date-filter.component.css'],
})
export class DateFilterComponent implements OnInit {
  @Input()
  listToFilter?: any;
  minDate: Date = new Date();
  constructor() {}

  ngOnInit(): void {}
}
