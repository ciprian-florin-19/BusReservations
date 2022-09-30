import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css'],
})
export class SearchResultsComponent implements OnInit {
  start!: string | null;
  destination!: string | null;
  date!: string | null;
  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParamMap.subscribe((params) => {
      this.start = params.get('start');
      this.destination = params.get('destination');
      this.date = params.get('date');
    });

    this.getAvailableRides();
  }
  getAvailableRides() {
    //TO DO call api to get data
    console.log(this.start);
    console.log(this.destination);
    console.log(this.date);
  }
}
