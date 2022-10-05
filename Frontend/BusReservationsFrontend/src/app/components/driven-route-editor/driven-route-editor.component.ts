import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BusDataSource } from 'src/app/data-sources/busDataSource';
import { RouteDataSource } from 'src/app/data-sources/routeDataSource';
import { PaginationParameters } from 'src/app/models/paginationParameters';
import { BusService } from 'src/app/services/bus.service';
import { DrivenRouteService } from 'src/app/services/driven-route.service';
import { BusDialogComponent } from '../bus-dialog/bus-dialog.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { MessageComponent } from '../message/message.component';
import { RouteDialogComponent } from '../route-dialog/route-dialog.component';

@Component({
  selector: 'app-driven-route-editor',
  templateUrl: './driven-route-editor.component.html',
  styleUrls: ['./driven-route-editor.component.css'],
})
export class DrivenRouteEditorComponent implements OnInit {
  dataSource!: RouteDataSource;
  columns: string[] = [
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
    private service: DrivenRouteService,
    private snackbar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.dataSource = new RouteDataSource(this.service);
    this.dataSource.getRoutes();
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
    this.dataSource.getRoutes(event.pageIndex + 1);
  }
  editRow(row: any) {
    const dialogRef = this.dialog.open(RouteDialogComponent, {
      data: {
        message: 'Modifica ruta',
        okMessage: 'Salveaza',
        cancelMessage: 'Inapoi',
        action: 'edit',
        routeId: row.id,
      },
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe({
      next: (r) => {
        if (r) {
          this.dataSource.getRoutes();
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
          this.service.deleteDrivenRoute(row.id).subscribe({
            next: () => {
              this.showMessage('Linia a fost stearsa cu succes', '');
              this.dataSource.getRoutes();
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
    const dialogRef = this.dialog.open(RouteDialogComponent, {
      data: {
        message: 'Adauga ruta',
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
          this.dataSource.getRoutes();
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
