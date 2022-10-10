import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, Observable } from 'rxjs';
import { Bus } from '../models/bus';
import { DrivenRoute } from '../models/drivenRoute';
import { PagedList } from '../models/PagedList';
import { PaginationParameters } from '../models/paginationParameters';
import { BusService } from '../services/bus.service';
import { DrivenRouteService } from '../services/driven-route.service';

export class RouteDataSource extends DataSource<any> {
  columns!: string[];
  private data = new BehaviorSubject<DrivenRoute[]>([]);
  paginationParams = new BehaviorSubject<PaginationParameters>({
    currentPage: 1,
    hasNext: false,
    hasPrevious: false,
    pageCount: 1,
    pageSize: 1,
    totalElementCount: 0,
  });
  constructor(private service: DrivenRouteService) {
    super();
  }
  connect(
    collectionViewer: CollectionViewer
  ): Observable<readonly DrivenRoute[]> {
    return this.data.asObservable();
  }
  disconnect(collectionViewer: CollectionViewer): void {
    this.data.complete();
  }
  getRoutes(index: number = 1) {
    this.service.getDrivenRoutes(index).subscribe({
      next: (d) => {
        console.log(d);
        this.data.next(d.items);
        this.paginationParams.next(d.paginationParameters);
        this.columns = Object.keys(d.items[0]);
      },
      error: (e) => {
        console.log(e);
      },
    });
  }
}
