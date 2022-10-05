import { DataSource } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BusDataSource } from 'src/app/data-sources/busDataSource';
import { Bus } from 'src/app/models/bus';
import { PaginationParameters } from 'src/app/models/paginationParameters';
import { BusService } from 'src/app/services/bus.service';
import { BusDialogComponent } from '../bus-dialog/bus-dialog.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { MessageComponent } from '../message/message.component';

@Component({
  selector: 'app-bus-editor',
  templateUrl: './bus-editor.component.html',
  styleUrls: ['./bus-editor.component.css'],
})
export class BusEditorComponent implements OnInit {
  dataSource!: BusDataSource;
  columns: string[] = ['name', 'capacity', 'actions'];
  paginationParameters!: PaginationParameters;
  elementCount!: number;
  constructor(
    private service: BusService,
    private snackbar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.dataSource = new BusDataSource(this.service);
    this.dataSource.getBuses();
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
    this.dataSource.getBuses(event.pageIndex + 1);
  }
  editRow(row: any) {
    const dialogRef = this.dialog.open(BusDialogComponent, {
      data: {
        message: 'Modifica autobuz',
        okMessage: 'Salveaza',
        cancelMessage: 'Inapoi',
        action: 'edit',
        busId: row.id,
      },
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe({
      next: (r) => {
        if (r) {
          this.dataSource.getBuses();
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
          this.service.deleteBus(row.id).subscribe({
            next: () => {
              this.showMessage('Linia a fost stearsa cu succes', '');
              this.dataSource.getBuses();
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
    const dialogRef = this.dialog.open(BusDialogComponent, {
      data: {
        message: 'Adauga autobuz',
        okMessage: 'Adauga',
        cancelMessage: 'Inapoi',
        action: 'add',
        busId: '',
      },
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe({
      next: (r) => {
        if (r) {
          this.dataSource.getBuses();
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
