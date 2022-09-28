import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css'],
})
export class RegisterFormComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  onSubmit(userInput: NgForm) {
    if (!userInput.valid) return;
    console.log(userInput.value);
  }
}
