import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Seat } from 'src/app/models/seat';

@Component({
  selector: 'app-add-reservation-view',
  templateUrl: './add-reservation-view.component.html',
  styleUrls: ['./add-reservation-view.component.css'],
})
export class AddReservationViewComponent implements OnInit {
  selectedSeat?: Seat;
  bdrId: string = '';
  constructor(private router: Router) {
    let navigation = router.getCurrentNavigation();
    if (navigation)
      if (navigation.extras.state) console.log(navigation.extras.state['data']);
  }

  ngOnInit(): void {}
}
