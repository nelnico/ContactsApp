import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class AccountService {

  private baseUrl = environment.apiUrl;

  private currentUserSource = new ReplaySubject<UserModel| undefined>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  login(username: string, password: string) {
    var url = this.baseUrl + "auth/login";
    var data= {
      username: username,
      password: password
    }
    return this.http.post<UserModel>(url, data).pipe(
      map((response: UserModel) => {
        console.log(response);
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        } else {
        }
      })
    );
  }

  setCurrentUser(user: UserModel) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(undefined);
  }


}
