import { JsonResultBase } from "./jsonresultbase";

export interface PagedListJsonResult<T> extends JsonResultBase {
  list: T[];
  count: number;
}
