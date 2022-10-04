import { NgFor } from '@angular/common';
import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ComponentCanDeactivate } from 'src/app/guards/changes-prompt.guard';
import { Account } from 'src/app/models/account';
import { AccountService } from 'src/app/services/account.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { ConfirmationComponent } from '../confirmation/confirmation.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit, ComponentCanDeactivate {
  constructor(
    private tokenStorage: TokenStorageService,
    private accountService: AccountService,
    private dialog: MatDialog
  ) {
    this.getUserData();
  }
  @HostListener('window:beforeunload')
  canDeactivate(): boolean | Observable<boolean> {
    console.log(this.editor.userForm?.dirty);
    console.log(this.editor.isSaved);
    if (this.editor.userForm?.dirty && !this.editor.isSaved) {
      const dialogRef = this.dialog.open(ConfirmationComponent, {
        data: {
          message: 'Vrei sa salvezi modificarile?',
          okMessage: 'Da',
          cancelMessage: 'Nu',
        },
        disableClose: true,
      });
      dialogRef.afterClosed().subscribe({
        next: (r) => {
          if (r) {
            this.editor.onSubmit(this.editor.userForm);
            this.editor.isSaved = true;
          } else {
            this.editor.onFailedUpdate();
            this.editor.displayData();
          }
          return true;
        },
      });
      return false;
    } else return true;
  }
  isAdmin: boolean = false;
  accountData?: Account;
  @ViewChild('editor')
  editor: any;
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
