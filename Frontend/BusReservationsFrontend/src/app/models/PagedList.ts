import { PaginationParameters } from './paginationParameters';

export interface PagedList<T> {
  items: T[];
  paginationParameters: PaginationParameters;
}
