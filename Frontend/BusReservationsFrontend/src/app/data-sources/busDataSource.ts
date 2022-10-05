import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { BehaviorSubject, Observable } from 'rxjs';
import { Bus } from '../models/bus';
import { PagedList } from '../models/PagedList';
import { PaginationParameters } from '../models/paginationParameters';
import { BusService } from '../services/bus.service';

export class BusDataSource extends DataSource<any> {
  columns!: string[];
  private data = new BehaviorSubject<Bus[]>([]);
  paginationParams = new BehaviorSubject<PaginationParameters>({
    currentPage: 1,
    hasNext: false,
    hasPrevious: false,
    pageCount: 1,
    pageSize: 1,
  });
  constructor(private service: BusService) {
    super();
  }
  connect(collectionViewer: CollectionViewer): Observable<readonly Bus[]> {
    return this.data.asObservable();
  }
  disconnect(collectionViewer: CollectionViewer): void {
    this.data.complete();
  }
  getBuses(index: number = 1) {
    this.service.getAllBuses(index).subscribe({
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
