import { JsonResultBase } from "./jsonresultbase";

export interface SingleJsonResult<T> extends JsonResultBase{
  result: T
}
