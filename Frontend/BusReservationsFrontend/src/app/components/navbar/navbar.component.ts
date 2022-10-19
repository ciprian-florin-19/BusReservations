import { Dialog } from '@angular/cdk/dialog';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
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
  @ViewChild('drawer')
  drawer?: MatSidenav;

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
    if (this.drawer?.opened)
      this.drawer.close().then(() => {
        this.dialog.open(LoginFormComponent);
      });
    else this.dialog.open(LoginFormComponent);
    console.log('login opened');
  }

  openRegisterForm() {
    if (this.drawer?.opened)
      this.drawer?.close().then(() => {
        this.dialog.open(RegisterFormComponent);
      });
    else this.dialog.open(RegisterFormComponent);
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
  navigate(link: string) {
    if (this.drawer?.opened)
      this.drawer?.close().then(() => {
        this.router.navigate([link]);
      });
    else this.router.navigate([link]);
  }
  onBackdropClick() {
    console.log('backdrop');
  }
}
