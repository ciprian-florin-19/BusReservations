import { Dialog } from '@angular/cdk/dialog';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginFormComponent } from '../login-form/login-form.component';
import { RegisterFormComponent } from '../register-form/register-form.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  constructor(private dialog: MatDialog) {}

  username: string = '';
  password: string = '';

  ngOnInit(): void {}

  openLoginForm() {
    this.dialog.open(LoginFormComponent);
    console.log('login opened');
  }

  openRegisterForm() {
    this.dialog.open(RegisterFormComponent);
    console.log('register opened');
  }
}
