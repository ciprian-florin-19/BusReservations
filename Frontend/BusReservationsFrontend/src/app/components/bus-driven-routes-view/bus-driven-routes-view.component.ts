import { Component, OnInit } from '@angular/core';
import { BusDrivenRoute } from 'src/app/models/busDrivenRoute';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';

@Component({
  selector: 'app-bus-driven-routes-view',
  templateUrl: './bus-driven-routes-view.component.html',
  styleUrls: ['./bus-driven-routes-view.component.css'],
})
export class BusDrivenRoutesViewComponent implements OnInit {
  result!: BusDrivenRoute[];
  constructor(private bdr: BusDrivenRoutesService) {}

  ngOnInit(): void {
    this.bdr.getAll().subscribe((r) => {
      this.result = r;
      console.log(this.result);
    });
  }
}
