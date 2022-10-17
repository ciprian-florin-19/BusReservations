import { NgFor } from '@angular/common';
import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ComponentCanDeactivate } from 'src/app/guards/changes-prompt.guard';
import { ComponentCanActivate } from 'src/app/guards/direct-link-input.guard';
import { Account } from 'src/app/models/account';
import { UserStates } from 'src/app/models/userStates';
import { AccountService } from 'src/app/services/account.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { ConfirmationComponent } from '../confirmation/confirmation.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent
  implements OnInit, ComponentCanDeactivate, ComponentCanActivate
{
  isRendered = false;
  constructor(
    private tokenStorage: TokenStorageService,
    private accountService: AccountService,
    private dialog: MatDialog,
    private router: Router
  ) {
    this.getUserData();
  }
  canActivate(permissions: UserStates): boolean | Observable<boolean> {
    if (permissions.isLoggedIn) return true;
    return false;
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
            this.editor.isSaved = true;
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
    this.isRendered = false;
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
  selectPanelData(index: number) {
    console.log(this.isRendered);

    if (index == 2 && !this.isRendered)
      this.router.navigateByUrl('/user/profile/bus-editor');
    this.isRendered = true;
  }
}
