import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ContactModel } from '../../models/contact.model';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.scss'],
})
export class ContactsListComponent {
  @Input() contacts: ContactModel[];
  @Output() delete = new EventEmitter<number>();

  onDelete(contact: ContactModel) {
    let confirmed = confirm(
      `Are you sure you want to delete ${contact.fullName}?`
    );
    if (confirmed) this.delete.emit(contact.id);
  }
}
