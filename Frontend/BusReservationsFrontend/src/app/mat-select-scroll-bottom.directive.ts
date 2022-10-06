import { Directive, EventEmitter, Output } from '@angular/core';
import { MatSelect } from '@angular/material/select';
import {
  Subject,
  filter,
  switchMap,
  fromEvent,
  throttleTime,
  takeUntil,
} from 'rxjs';

@Directive({
  selector: '[appMatSelectScrollBottom]',
})
export class MatSelectScrollBottomDirective {
  private readonly BOTTOM_SCROLL_OFFSET = 25;
  @Output('appMatSelectScrollBottom') reachedBottom = new EventEmitter<void>();
  unsubscribeAll = new Subject<boolean>();

  constructor(private matSelect: MatSelect) {
    this.matSelect.openedChange
      .pipe(
        filter((isOpened) => !!isOpened),
        switchMap((isOpened) =>
          fromEvent(this.matSelect.panel.nativeElement, 'scroll').pipe(
            throttleTime(50)
          )
        ), //controles the thrasold of scroll event
        takeUntil(this.unsubscribeAll)
      )
      .subscribe((event: any) => {
        console.log('scroll');
        // console.log(event, event.target.scrollTop, event.target.scrollHeight);
        if (
          event.target.scrollTop >=
          event.target.scrollHeight -
            event.target.offsetHeight -
            this.BOTTOM_SCROLL_OFFSET
        ) {
          this.reachedBottom.emit();
        }
      });
  }
  ngOnDestroy(): void {
    this.unsubscribeAll.next(true);
    this.unsubscribeAll.complete();
  }
}
