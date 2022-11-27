import { SearchParamsModel } from "./search-params.model";

export class ContactSearchParamsModel extends SearchParamsModel {
  query?: string;
  regionIds: number[] = [];
  genderId?: number
}
