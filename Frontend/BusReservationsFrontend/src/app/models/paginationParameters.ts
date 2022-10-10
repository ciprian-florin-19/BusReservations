export interface PaginationParameters {
  currentPage: number;
  pageCount: number;
  pageSize: number;
  totalElementCount: number;
  hasNext: boolean;
  hasPrevious: boolean;
}
