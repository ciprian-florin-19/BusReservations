import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { BdrDataSource } from 'src/app/data-sources/bdrDataSource';
import { BusDataSource } from 'src/app/data-sources/busDataSource';
import { ComponentCanActivate } from 'src/app/guards/direct-link-input.guard';
import { PaginationParameters } from 'src/app/models/paginationParameters';
import { UserStates } from 'src/app/models/userStates';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { BusService } from 'src/app/services/bus.service';
import { BdrDialogComponent } from '../bdr-dialog/bdr-dialog.component';
import { BusDialogComponent } from '../bus-dialog/bus-dialog.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { MessageComponent } from '../message/message.component';

@Component({
  selector: 'app-bdr-editor',
  templateUrl: './bdr-editor.component.html',
  styleUrls: ['./bdr-editor.component.css'],
})
export class BdrEditorComponent implements OnInit, ComponentCanActivate {
  dataSource!: BdrDataSource;
  columns: string[] = [
    'busName',
    'capacity',
    'seats',
    'start',
    'destination',
    'departure',
    'arrival',
    'price',
    'actions',
  ];
  paginationParameters!: PaginationParameters;
  elementCount!: number;
  constructor(
    private bdrService: BusDrivenRoutesService,
    private snackbar: MatSnackBar,
    private dialog: MatDialog
  ) {}
  canActivate(permissions: UserStates): boolean | Observable<boolean> {
    if (permissions.isAdmin) return true;
    return false;
  }

  ngOnInit(): void {
    this.dataSource = new BdrDataSource(this.bdrService);
    this.dataSource.getBdr();
    this.dataSource.paginationParams.subscribe({
      next: (p) => {
        this.paginationParameters = p;
        this.paginationParameters.currentPage--;
        this.elementCount = p.pageSize * p.pageCount;
      },
    });
  }

  getPage(event: any) {
    console.log(event.pageIndex);
    this.dataSource.getBdr(event.pageIndex + 1);
  }
  editRow(row: any) {
    const dialogRef = this.dialog.open(BdrDialogComponent, {
      data: {
        message: 'Modifica Cursa',
        okMessage: 'Salveaza',
        cancelMessage: 'Inapoi',
        action: 'edit',
        bdrId: row.id,
      },
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe({
      next: (r) => {
        if (r) {
          this.dataSource.getBdr();
        }
      },
    });
  }
  deleteRow(row: any) {
    const dialogRef = this.dialog.open(ConfirmationComponent, {
      data: {
        message: 'Esti sigur ca vrei sa stergi linia?',
        okMessage: 'Da',
        cancelMessage: 'Nu',
      },
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe({
      next: (r) => {
        if (r) {
          this.bdrService.deleteBusDrivenRoute(row.id).subscribe({
            next: () => {
              this.showMessage('Linia a fost stearsa cu succes', '');
              this.dataSource.getBdr();
            },
            error: (e) => {
              this.showMessage('Linia nu a fost stearsa', '');
            },
          });
        }
      },
    });
  }

  addRow() {
    const dialogRef = this.dialog.open(BdrDialogComponent, {
      data: {
        message: 'Adauga Cursa',
        okMessage: 'Adauga',
        cancelMessage: 'Inapoi',
        action: 'add',
        bdrId: '',
      },
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe({
      next: (r) => {
        if (r) {
          this.dataSource.getBdr();
        }
      },
    });
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
