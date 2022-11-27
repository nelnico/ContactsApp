import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PaginationModel } from '../../models/pagination.model';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
})
export class PaginationComponent {
  @Input() pagination: PaginationModel;
  @Output() goToNextPage = new EventEmitter();
  @Output() goToPreviousPage = new EventEmitter();

  onGoToNextPage() {
    this.goToNextPage.emit();
  }

  onGoToPreviousPage() {
    this.goToPreviousPage.emit();
  }
}
