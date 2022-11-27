import { Component, OnInit } from '@angular/core';
import { ContactSearchParamsModel } from '../_shared/models/contact-search-params.model';
import { ContactModel } from '../_shared/models/contact.model';
import { PaginatedResultModel } from '../_shared/models/paginated-result.model';
import { PaginationModel } from '../_shared/models/pagination.model';
import { ContactsService } from '../_shared/services/contacts.service';
import { NotificationService } from '../_shared/services/notification.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  isBusy: boolean = false;
  contacts: ContactModel[] = [];
  searchParams: ContactSearchParamsModel = new ContactSearchParamsModel();
  pagination: PaginationModel;

  constructor(
    private contactsService: ContactsService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.getContacts();
  }

  getContacts() {
    this.isBusy = true;
    this.contactsService.findContacts(this.searchParams).subscribe({
      next: (response: PaginatedResultModel<ContactModel[]>) => {
        this.pagination = response.pagination;
        this.contacts = response.result;
      },
      error: (error) => {
        this.isBusy = false;
        this.notificationService.error(
          'Contacts',
          'Failed retrieving contacts'
        );
      },
      complete: () => {
        this.isBusy = false;
      },
    });
  }

  onPreviousPage() {
    this.searchParams.pageNumber -= 1;
    this.getContacts();
  }

  onNextPage() {
    this.searchParams.pageNumber += 1;
    this.getContacts();
  }

  onDeleteContact(event: number) {
    this.isBusy = true;
    this.contactsService.deleteContact(event).subscribe({
      next: () => {
        this.getContacts();
      },
      error: (error) => {
        this.isBusy = false;
        this.notificationService.error(
          'Contacts',
          'Failed deleting contact'
        );
      },
      complete: () => {
        this.isBusy = false;
      },
    });
  }
}
