import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_shared/services/account.service';
import { NotificationService } from 'src/app/_shared/services/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  private isBusy: boolean = false;

  constructor(
    private accountService: AccountService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  loginForm = new FormGroup({
    username: new FormControl('admin@mysite.com', [Validators.required]),
    password: new FormControl('Password@123', [Validators.required]),
  });

  onSubmit() {
    this.isBusy = true;
    let controls = this.loginForm.controls;
    this.accountService
      .login(controls.username.value, controls.password.value)
      .subscribe({
        next: (response) => {
          console.log(response);
          this.accountService.currentUser$.subscribe();
          this.router.navigateByUrl('/');
        },
        error: (error) => {
          this.isBusy = false;
          this.notificationService.error('Login', 'Invalid credentials');
        },
        complete: () => {
          this.isBusy = false;
        },
      });
  }
}
