import {
  Component,
  ElementRef,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { Router } from '@angular/router';
import { BusDrivenRoute } from 'src/app/models/busDrivenRoute';
import { busDrivenRoutePagedList } from 'src/app/models/busDrivenRoutePagedList';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { BusSchemaComponent } from '../bus-schema/bus-schema.component';

@Component({
  selector: 'app-bus-driven-routes-view',
  templateUrl: './bus-driven-routes-view.component.html',
  styleUrls: ['./bus-driven-routes-view.component.css'],
})
export class BusDrivenRoutesViewComponent implements OnInit {
  result?: busDrivenRoutePagedList;
  elementCount: number = 0;
  isLoading: boolean = true;
  @ViewChild('schema')
  busSchema?: BusSchemaComponent;
  constructor(private bdr: BusDrivenRoutesService) {}

  ngOnInit(): void {
    this.bdr.getAll().subscribe((r) => {
      this.result = r;
      this.isLoading = false;
      this.result.currentPage--;
      this.elementCount = r.pageCount * r.pageSize;
    });
  }

  onPageChange(event: any) {
    window.scroll(0, 0);
    this.bdr.getAll(event.pageIndex + 1).subscribe((r) => {
      this.result = r;
      this.isLoading = false;
      this.result.currentPage--;
      this.elementCount = r.pageCount * r.pageSize;
    });
  }
}
