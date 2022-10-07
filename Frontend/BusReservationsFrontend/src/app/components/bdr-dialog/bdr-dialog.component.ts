import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {
  MatAutocomplete,
  MatAutocompleteTrigger,
} from '@angular/material/autocomplete';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSelect } from '@angular/material/select';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Route } from '@angular/router';
import { fromEvent, map, takeUntil } from 'rxjs';
import { Bus } from 'src/app/models/bus';
import { DrivenRoute } from 'src/app/models/drivenRoute';
import { BusDrivenRoutesService } from 'src/app/services/bus-driven-routes.service';
import { BusService } from 'src/app/services/bus.service';
import { DrivenRouteService } from 'src/app/services/driven-route.service';
import { MessageComponent } from '../message/message.component';

@Component({
  selector: 'app-bdr-dialog',
  templateUrl: './bdr-dialog.component.html',
  styleUrls: ['./bdr-dialog.component.css'],
})
export class BdrDialogComponent implements OnInit {
  isLoading: boolean = false;
  @ViewChild('busData')
  form?: NgForm;
  buses: { items: Bus[]; hasNext: boolean; currentPage: number } = {
    items: [],
    hasNext: true,
    currentPage: 0,
  };
  routes: { items: DrivenRoute[]; hasNext: boolean; currentPage: number } = {
    items: [],
    hasNext: true,
    currentPage: 1,
  };
  selectedBus?: Bus;
  selectedRoute?: DrivenRoute;
  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: {
      message: string;
      okMessage: string;
      cancelMessage: string;
      action: string;
      bdrId: string;
    },
    private service: BusDrivenRoutesService,
    private busService: BusService,
    private routeService: DrivenRouteService,
    private snackbar: MatSnackBar,
    private datePipe: DatePipe
  ) {}
  /*@ViewChild(MatAutocompleteTrigger)
  autocompleteTrigger!: MatAutocompleteTrigger;

  autocompleteScroll(autoComplete: MatAutocomplete) {
    console.log(autoComplete);
    console.log(this.autocompleteTrigger);

    setTimeout(() => {
      if (autoComplete && this.autocompleteTrigger && autoComplete.panel) {
        fromEvent(autoComplete.panel.nativeElement, 'scroll')
          .pipe(
            map((x) => autoComplete.panel.nativeElement.scrollTop),
            takeUntil(this.autocompleteTrigger.panelClosingActions)
          )
          .subscribe((x) => {
            const scrollTop = autoComplete.panel.nativeElement.scrollTop;
            const scrollHeight = autoComplete.panel.nativeElement.scrollHeight;
            const elementHeight = autoComplete.panel.nativeElement.clientHeight;
            const atBottom = scrollHeight === scrollTop + elementHeight;
            if (atBottom) {
              if (autoComplete.id == 'mat-autocomplete-0')
                this.fetchBuses(++this.buses.currentPage);
              else this.fetchRoutes(++this.routes.currentPage);
            }
          });
      }
    });
  }*/
  ngOnInit(): void {
    this.fetchBuses();
    this.fetchRoutes();
    this.fetchSelection();
  }

  fetchBuses(page: number = 1) {
    if (!this.buses.hasNext) return;
    console.log('fetch');

    this.busService.getAllBuses(page).subscribe({
      next: (r) => {
        this.buses.items = this.buses.items.concat(r.items);
        this.buses.hasNext = r.paginationParameters.hasNext;
        this.buses.currentPage = r.paginationParameters.currentPage;
      },
      error: (e) => {
        console.log(e);
      },
    });
  }

  fetchSelection() {
    if (this.data.action == 'edit')
      this.service.getBusDrivenRouteById(this.data.bdrId).subscribe({
        next: (bdr) => {
          this.selectedBus = bdr.bus;
          this.selectedRoute = bdr.drivenRoute;

          if (this.buses.items.includes(this.selectedBus))
            this.buses.items.splice(this.buses.items.indexOf(this.selectedBus));
          if (this.routes.items.includes(this.selectedRoute))
            this.routes.items.splice(
              this.routes.items.indexOf(this.selectedRoute)
            );
          this.routes.items.unshift(this.selectedRoute);
        },
      });
  }

  fetchRoutes(page: number = 1) {
    if (!this.routes.hasNext) return;
    this.routeService.getDrivenRoutes(page).subscribe({
      next: (r) => {
        this.routes.items = this.routes.items.concat(r.items);
        this.routes.hasNext = r.paginationParameters.hasNext;
        this.routes.currentPage = r.paginationParameters.currentPage;
      },
      error: (e) => {
        console.log(e);
      },
    });
  }
  onSubmit() {
    console.log('submitted');

    if (this.data.action == 'edit') this.updateBdr();
    else this.addBdr();
  }
  updateBdr() {
    if (this.selectedBus && this.selectedRoute)
      this.service
        .updateBusDrivenRoute(this.data.bdrId, {
          busId: this.selectedBus.id,
          drivenRouteId: this.selectedRoute.id,
        })
        .subscribe({
          next: () => {
            this.showMessage('Modificarile au fost salvate', '');
          },
          error: (e) => {
            this.showMessage('Modificarile nu au fost salvate', '');
            console.log(e);
          },
        });
  }
  addBdr() {
    if (this.selectedBus && this.selectedRoute)
      this.service
        .addBusDrivenRoute({
          busId: this.selectedBus.id,
          drivenRouteId: this.selectedRoute.id,
        })
        .subscribe({
          next: () => {
            this.showMessage('Autobuzul a fost adaugat cu succes', '');
          },
          error: (e) => {
            console.log({
              busId: this.selectedBus?.id,
              drivenRouteId: this.selectedRoute?.id,
            });

            this.showMessage('Autobuzul nu a putut fi adaugat', '');
            console.log(e);
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
