import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent {
@Input() totalCount?: number;
@Input() pageSize?: number;
@Output() pageChange = new EventEmitter<number>();

onPagerChanged(event: any){
  this.pageChange.emit(event.page);
}
}
