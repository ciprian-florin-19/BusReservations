import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AccountPutPostDto } from 'src/app/models/accountPutPostDto';
import { UserPutPostDto } from 'src/app/models/userPutPostDto';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { LoginFormComponent } from '../login-form/login-form.component';
import { MessageComponent } from '../message/message.component';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css'],
})
export class RegisterFormComponent implements OnInit {
  constructor(
    private authService: AuthenticationService,
    private tokenStorage: TokenStorageService,
    private dialog: MatDialog,
    private snackbar: MatSnackBar,
    private router: Router
  ) {}
  isLoading: boolean = false;
  ngOnInit(): void {}

  onSubmit(userInput: NgForm) {
    if (!userInput.valid) return;
    this.isLoading = true;
    const userData: AccountPutPostDto = {
      user: {
        fullname: userInput.value.name,
        phoneNumber: userInput.value.phone,
        email: userInput.value.email,
      },
      username: userInput.value.username,
      password: userInput.value.password,
    };
    console.log(userData);

    this.authService.register(userData).subscribe({
      next: () => {
        this.onSuccessRegister();
        this.dialog.closeAll();
        this.dialog.open(LoginFormComponent);
      },
      error: (e) => {
        console.log('register failed!');
        this.dialog.closeAll();
        this.onFailedRegister();
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
      },
    });
  }
  private onSuccessRegister() {
    const message = 'Cont creat cu succes';
    let name: string = '';
    this.showMessage(message, name);
  }
  private onFailedRegister() {
    const message = 'Contul nu a putut fi creat';
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
