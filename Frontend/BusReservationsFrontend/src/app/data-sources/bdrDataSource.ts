import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, Observable } from 'rxjs';
import { Bus } from '../models/bus';
import { BusDrivenRoute } from '../models/busDrivenRoute';
import { PagedList } from '../models/PagedList';
import { PaginationParameters } from '../models/paginationParameters';
import { BusDrivenRoutesService } from '../services/bus-driven-routes.service';
import { BusService } from '../services/bus.service';

export class BdrDataSource extends DataSource<any> {
  columns!: string[];
  private data = new BehaviorSubject<BusDrivenRoute[]>([]);
  paginationParams = new BehaviorSubject<PaginationParameters>({
    currentPage: 1,
    hasNext: false,
    hasPrevious: false,
    pageCount: 1,
    pageSize: 1,
    totalElementCount: 0,
  });
  constructor(private service: BusDrivenRoutesService) {
    super();
  }
  connect(
    collectionViewer: CollectionViewer
  ): Observable<readonly BusDrivenRoute[]> {
    return this.data.asObservable();
  }
  disconnect(collectionViewer: CollectionViewer): void {
    this.data.complete();
  }
  getBdr(index: number = 1) {
    this.service.getAll(index).subscribe({
      next: (b) => {
        this.data.next(b.items);
        this.paginationParams.next(b.paginationParameters);
        this.columns = Object.keys(b.items[0]);
      },
      error: (e) => {
        console.log(e);
      },
    });
  }
}
