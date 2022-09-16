import { Component } from '@angular/core';
import { IUser } from './interfaces/IUser';
import { Status } from './interfaces/Status';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'BusReservationsFrontend';
}
