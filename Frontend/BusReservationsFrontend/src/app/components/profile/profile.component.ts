import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Account } from 'src/app/models/account';
import { AccountService } from 'src/app/services/account.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  constructor(
    private tokenStorage: TokenStorageService,
    private accountService: AccountService
  ) {
    this.getUserData();
  }
  isAdmin: boolean = false;
  accountData?: Account;
  ngOnInit(): void {
    if (this.tokenStorage.getSession().roles.includes('admin')) {
      this.isAdmin = true;
    }
  }

  private getUserData() {
    this.accountService
      .getAccountById(this.tokenStorage.getSession().accountId)
      .subscribe({
        next: (a) => {
          this.accountData = a;
        },
        error: (e) => {
          console.log(e);
        },
      });
  }
  onUpdate(userForm: NgForm) {
    this.getUserData();
    console.log(this.accountData);
    console.log('updated');
  }
}
