import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { LoginData } from 'src/app/models/loginData';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
})
export class LoginFormComponent implements OnInit {
  constructor() {}
  ngOnInit(): void {}

  onSubmit(userInput: NgForm) {
    if (!userInput.valid) return;
    console.log('submitted');
    console.log(userInput.value);

    //TO DO perform login
  }
}
