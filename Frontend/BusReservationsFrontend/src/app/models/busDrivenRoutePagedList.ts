import { BusDrivenRoute } from './busDrivenRoute';

export interface busDrivenRoutePagedList {
  busDrivenRoutes: BusDrivenRoute[];
  currentPage: number;
  pageCount: number;
  pageSize: number;
  hasNext: boolean;
  hasPrevious: boolean;
}
