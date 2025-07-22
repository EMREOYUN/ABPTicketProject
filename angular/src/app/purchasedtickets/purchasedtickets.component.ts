import { Component, inject, OnInit } from '@angular/core';
import { ConfigStateService, ListService } from '@abp/ng.core';
import { EventService } from '../proxy/events';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-purchasedtickets',
  templateUrl: './purchasedtickets.component.html',
  styleUrl: './purchasedtickets.component.scss',
  standalone: false,
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }]
})
export class PurchasedticketsComponent implements OnInit {
  tickets: any[] = [];
  loading: boolean = false;
  config: ConfigStateService = inject(ConfigStateService);

  constructor(private eventService: EventService) {}

  ngOnInit(): void {
    this.loadTickets();
  }

  loadTickets() {
    this.loading = true;
    this.eventService.getMyPurchasedTickets().subscribe(async (tickets) => {
      // Fetch event details for each ticket
      const ticketDetails = await Promise.all(
        tickets.map(async (ticket: any) => {
          if (ticket.eventId) {
            try {
              const event = await this.eventService.get(ticket.eventId).toPromise();
              // Preserve ticket id as ticketId, event id as eventId
              return { ...event, ...ticket, ticketId: ticket.id };
            } catch (e) {
              return { ...ticket, ticketId: ticket.id };
            }
          }
          return { ...ticket, ticketId: ticket.id };
        })
      );
      this.tickets = ticketDetails;
      this.loading = false;
    });
  }

  getUsername() {
    return this.config.getOne('currentUser')?.userName || '';
  }
}
