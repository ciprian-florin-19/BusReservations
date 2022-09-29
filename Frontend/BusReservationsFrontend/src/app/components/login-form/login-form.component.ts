import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { LoginData } from 'src/app/models/loginData';
import { AccountService } from 'src/app/services/account.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { UserServiceService } from 'src/app/services/user-service.service';
import { MessageComponent } from '../message/message.component';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
})
export class LoginFormComponent implements OnInit {
  constructor(
    private authService: AuthenticationService,
    private tokenStorage: TokenStorageService,
    private dialog: MatDialog,
    private snackbar: MatSnackBar,
    private router: Router,
    private accountService: AccountService
  ) {}
  isLoading: boolean = false;

  ngOnInit(): void {}

  onSubmit(userInput: NgForm) {
    if (!userInput.valid) return;
    this.isLoading = true;
    console.log('submitted');
    console.log(userInput.value);
    this.authService
      .logIn(userInput.value.username, userInput.value.password)
      .subscribe({
        next: (r) => {
          this.tokenStorage.token = r.token;
          this.tokenStorage.saveSession();
          this.dialog.closeAll();
          console.log(this.tokenStorage.exists.value);
          this.onSuccessFullLogin();
        },
        error: (e) => {
          console.log('login failed!');
          console.log(this.tokenStorage.exists.value);
          this.onFailedLogin();
          this.isLoading = false;
        },
        complete: () => {
          this.isLoading = false;
        },
      });
  }
  private onSuccessFullLogin() {
    const message = 'Bine ai venit';
    this.accountService
      .getAccountById(this.tokenStorage.getSession().accountId)
      .subscribe((r) => {
        this.showMessage(message, r.username);
      });
  }
  private onFailedLogin() {
    const message = 'Parola sau Numele de Utilizator sunt gresite';
    let name: string = '';
    this.showMessage(message, name);
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
