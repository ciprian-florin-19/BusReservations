import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatSnackBar, MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css'],
})
export class MessageComponent implements OnInit {
  constructor(
    @Inject(MAT_SNACK_BAR_DATA) public data: { message: string; name: string }
  ) {}
  ngOnInit(): void {}
}
