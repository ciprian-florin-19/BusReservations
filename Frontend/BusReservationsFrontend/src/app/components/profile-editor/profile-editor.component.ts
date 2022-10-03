import {
  Component,
  EventEmitter,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Account } from 'src/app/models/account';
import { AccountPutPostDto } from 'src/app/models/accountPutPostDto';
import { AccountService } from 'src/app/services/account.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { LoginFormComponent } from '../login-form/login-form.component';
import { MessageComponent } from '../message/message.component';

@Component({
  selector: 'app-profile-editor',
  templateUrl: './profile-editor.component.html',
  styleUrls: ['./profile-editor.component.css'],
})
export class ProfileEditorComponent implements OnInit {
  constructor(
    private authService: AuthenticationService,
    private tokenStorage: TokenStorageService,
    private dialog: MatDialog,
    private snackbar: MatSnackBar,
    private router: Router,
    private accountService: AccountService
  ) {}
  isLoading: boolean = false;
  accountData?: Account;
  @ViewChild('userInput')
  userForm?: NgForm;

  @Output()
  onSubmitEmitter: EventEmitter<NgForm> = new EventEmitter();

  ngOnInit(): void {
    this.accountService
      .getAccountById(this.tokenStorage.getSession().accountId)
      .subscribe({
        next: (a) => {
          this.accountData = a;
          this.displayData();
        },
        error: (e) => {
          console.log(e);
        },
      });
  }

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
    this.accountService
      .updateAccount(this.tokenStorage.getSession().accountId, userData)
      .subscribe({
        next: (a) => {
          this.onSubmitEmitter.emit(userInput);
          this.onSuccessUpdate();
        },
        error: (e) => {
          this.onFailedUpdate();
          console.log(e);
        },
      });
  }
  private onSuccessUpdate() {
    const message = 'Modificarile au fost salvate';
    let name: string = '';
    this.showMessage(message, name);
  }
  private onFailedUpdate() {
    const message = 'Nu s-au putut salva modificarile';
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
  displayData() {
    this.userForm?.setValue({
      name: this.accountData?.user.fullName,
      phone: this.accountData?.user.phoneNumber,
      email: this.accountData?.user.email,
      username: this.accountData?.username,
      password: this.accountData?.password,
    });
  }
}
