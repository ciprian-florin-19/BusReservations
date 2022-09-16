import {
  Component,
  ContentChild,
  ElementRef,
  OnInit,
  ViewChild,
} from '@angular/core';
import { IBus } from 'src/app/interfaces/IBus';
import { IUser } from 'src/app/interfaces/IUser';
import { Status } from 'src/app/interfaces/Status';
import { ButtonComponent } from '../button/button.component';
import { TableComponent } from '../table/table.component';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css'],
})
export class ContainerComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  dummyData1: IUser[] = [
    {
      id: '1',
      name: 'Vasile',
      email: 'vasile1@gmail.com',
      phoneNumber: '0712345678',
      status: Status.regular,
    },
    {
      id: '2',
      name: 'Vasile',
      email: 'vasile1@gmail.com',
      phoneNumber: '0712345678',
      status: Status.regular,
    },
  ];
  dummyData2: IBus[] = [
    {
      id: '1',
      name: 'Bus1',
      capacity: 30,
    },
  ];

  @ViewChild(TableComponent)
  table!: TableComponent;

  @ViewChild(ButtonComponent)
  button!: ButtonComponent;

  toggleClick() {
    this.table.isVisible = !this.table.isVisible;
    if (this.table.isVisible) {
      this.button.text = 'Hide';
      this.button.color = 'red';
    } else {
      this.button.text = 'Show';
      this.button.color = 'green';
    }
  }
  setDataSource<T>(source: T[]) {
    this.table.source = source;
  }
}
