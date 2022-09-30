import { Dialog } from '@angular/cdk/dialog';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { BehaviorSubject, distinctUntilChanged } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { LoginFormComponent } from '../login-form/login-form.component';
import { MessageComponent } from '../message/message.component';
import { RegisterFormComponent } from '../register-form/register-form.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  username: string = '';
  password: string = '';
  isLoggedIn?: boolean;

  constructor(
    private dialog: MatDialog,
    public tokenStorage: TokenStorageService,
    private snackbar: MatSnackBar,
    private accountService: AccountService,
    private router: Router
  ) {
    tokenStorage.exists.subscribe((r) => {
      this.isLoggedIn = r;
      console.log(r);
    });
  }

  ngOnInit(): void {
    console.log(this.tokenStorage.exists);
  }

  openLoginForm() {
    this.dialog.open(LoginFormComponent);
    console.log('login opened');
  }

  openRegisterForm() {
    this.dialog.open(RegisterFormComponent);
    console.log('register opened');
  }

  logOut() {
    const message = 'La revedere';
    this.accountService
      .getAccountById(this.tokenStorage.getSession().accountId)
      .subscribe((r) => {
        this.showMessage(message, r.username);
      });
    this.tokenStorage.clearSession();
    this.router.navigateByUrl('');
  }

  private showMessage(message: string, name: string) {
    this.snackbar.openFromComponent(MessageComponent, {
      duration: 2000,
      data: {
        message: message,
        name: name,
      },
    });
  }
}
