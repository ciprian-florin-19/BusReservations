import { DataSource } from '@angular/cdk/collections';
import { Component, Input, OnInit } from '@angular/core';
import { BusDataSource } from 'src/app/data-sources/busDataSource';

@Component({
  selector: 'app-raw-data-editor',
  templateUrl: './raw-data-editor.component.html',
  styleUrls: ['./raw-data-editor.component.css'],
})
export class RawDataEditorComponent implements OnInit {
  @Input()
  dataSource!: DataSource<any>;
  @Input()
  columns!: string[];

  constructor() {}

  ngOnInit(): void {}
}
