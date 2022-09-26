import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Seat } from 'src/app/models/seat';

@Component({
  selector: 'app-add-reservation-view',
  templateUrl: './add-reservation-view.component.html',
  styleUrls: ['./add-reservation-view.component.css'],
})
export class AddReservationViewComponent implements OnInit {
  formData!: {
    bdrId: string;
    seatNumber: number;
  };
  constructor(private router: Router) {
    let navigation = router.getCurrentNavigation();
    if (navigation)
      if (navigation.extras.state)
        this.formData = navigation.extras.state['data'];
    console.log(this.formData);
  }

  ngOnInit(): void {}
}
