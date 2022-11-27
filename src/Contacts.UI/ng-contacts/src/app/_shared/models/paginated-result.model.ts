import { PaginationModel } from "./pagination.model";

export class PaginatedResultModel<T> {
  result: T | undefined;
  pagination: PaginationModel | undefined;
}
