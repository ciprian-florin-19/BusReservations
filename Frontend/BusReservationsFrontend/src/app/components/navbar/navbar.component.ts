import { Dialog } from '@angular/cdk/dialog';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BehaviorSubject, distinctUntilChanged } from 'rxjs';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { LoginFormComponent } from '../login-form/login-form.component';
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
    public tokenStorage: TokenStorageService
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
}
