import { KeyValue } from '@angular/common';
import {
  Component,
  ContentChild,
  ElementRef,
  Input,
  OnInit,
} from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit {
  constructor() {}

  @Input()
  source: any[] = [];

  isVisible: boolean = true;

  @ContentChild('projection')
  projection!: ElementRef;

  ngOnInit(): void {}
  ngAfterContentInit(): void {
    this.projection.nativeElement.innerHTML = 'Content projection works!';
  }
  unsorted(a: KeyValue<string, unknown>, b: KeyValue<string, unknown>) {
    return 0;
  }
}
