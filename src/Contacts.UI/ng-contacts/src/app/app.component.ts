import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from './_shared/models/user.model';
import { AccountService } from './_shared/services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {

  constructor(
    public accountService: AccountService,
    private router: Router) {}

  ngOnInit(): void {
    var storedData = localStorage.getItem('user');
    if (storedData) {
      var user: UserModel = JSON.parse(storedData);
      if (user) {
        this.accountService.setCurrentUser(user);
      }
    }
  }

  onLogout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
    return false;

  }
}
