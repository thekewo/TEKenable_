import { HttpClient, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Action } from "rxjs/internal/scheduler/Action";
import { User } from "../models/user";
import { SingleJsonResult } from "../models/singlejsonresult";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})

export class UserService {
  private url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  submitNewsletter(user: User): Observable<SingleJsonResult<boolean>> {
    var params = new HttpParams()
      .set("email", user.email)
      .set("contactSource", user.contactSource)
      .set("contactReason", user.contactReason)

    return this.http.post<SingleJsonResult<boolean>>(this.url + "user/submit", "", { params: params });
  }

  isEmailInDatabase(email: string): Observable<SingleJsonResult<boolean>> {
    var params = new HttpParams()
      .set("email", email)
    return this.http.get<SingleJsonResult<boolean>>(this.url + 'user/checkemail', { params: params });
  }
}
