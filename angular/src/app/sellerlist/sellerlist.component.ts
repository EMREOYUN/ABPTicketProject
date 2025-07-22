import { Component, inject, OnInit } from '@angular/core';
import { ConfigStateService, ListService, PagedResultDto } from '@abp/ng.core';
import { EventService, EventDto } from '../proxy/events'; // Assuming you have an EventService for handling event-related logic
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-event',
  standalone: false,
  templateUrl: './sellerlist.component.html',
  styleUrl: './sellerlist.component.scss',
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }]
})
export class SellerlistComponent implements OnInit {
  events = { items: [], totalCount: 0 } as PagedResultDto<EventDto>;
  selectedEvent = {} as EventDto;

  config: ConfigStateService = inject(ConfigStateService);

  isModalOpen = false;
  form: FormGroup; // add this line

  constructor(public readonly list: ListService, private eventService: EventService, private fb: FormBuilder, private confirmation: ConfirmationService) {}

  ngOnInit(): void {
    const eventStream = (query) => this.eventService.getSellerEvents(query);

    this.list.hookToQuery(eventStream).subscribe((result) => {
      this.events = result;
    });
  }

  getUsername() {
    return this.config.getOne("currentUser").userName;
  }

  createEvent() {
    this.buildForm();
    this.isModalOpen = true;
  }

  editEvent(id: string) {
    this.eventService.get(id).subscribe((eventObject) => {
      this.selectedEvent = eventObject;
      this.buildForm(eventObject);
      this.isModalOpen = true;
    });
  }

  deleteEvent(id: string) {
    this.confirmation.warn('::Menu:AreYouSureToDelete', '::Menu:AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.eventService.get(id).subscribe((eventObject) => {
          // Set event.active to false to delete the event
          const updateDto = {
            name: eventObject.name,
            description: eventObject.description,
            price: eventObject.price,
            quota: eventObject.quota,
            userQuota: eventObject.userQuota,
            ageRestriction: eventObject.ageRestriction,
            date: eventObject.date,
            location: eventObject.location,
            imageURL: eventObject.imageURL,
            active: false
          };
          this.eventService.update(id, updateDto).subscribe(() => {
            this.list.get(); // Refresh the list after deletion
          });
        });
      }
    });
  }


  buildForm(event?: EventDto) {
    let dateValue = '';
    if (event?.date) {
      // Try to parse and format as yyyy-MM-dd for input[type=date]
      const d = new Date(event.date);
      if (!isNaN(d.getTime())) {
        dateValue = d.toISOString().slice(0, 10);
      } else {
        dateValue = event.date;
      }
    }
    this.form = this.fb.group({
      name: [event?.name || '', Validators.required],
      description: [event?.description || '', Validators.required],
      price: [event?.price ?? 0, [Validators.required, Validators.min(0.01)]],
      quota: [event?.quota ?? 0, [Validators.required, Validators.min(1)]],
      userQuota: [event?.userQuota ?? 0, [Validators.required, Validators.min(1)]],
      ageRestriction: [event?.ageRestriction ?? false],
      date: [dateValue, Validators.required],
      location: [event?.location || '', Validators.required],
      imageURL: [event?.imageURL || '', [Validators.required, Validators.pattern('https?://.+')]],
    });
  }

  save() {
    if (this.form.valid) {
      const eventData = this.form.value;
      eventData.active = true;
      eventData.creatorId = this.config.getOne("currentUser").id;
      const request = this.selectedEvent.id ? this.eventService.update(this.selectedEvent.id, this.form.value) : this.eventService.create(this.form.value);
      request.subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get(); // Refresh the list after saving
      });
    }
  }
}
