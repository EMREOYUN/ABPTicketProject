import { Component, OnInit } from '@angular/core';
import { EventService } from '../proxy/events/event.service';
import type { EventDto } from '../proxy/events/models';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-favorites',
  standalone: false,
  templateUrl: './favorites.component.html',
  styleUrl: './favorites.component.scss'
})
export class FavoritesComponent implements OnInit {
  favoriteEvents: EventDto[] = [];
  selectedEvent = {} as EventDto;
  loading = false;
  isModalOpen = false;

  constructor(private eventService: EventService, private confirmation: ConfirmationService) {}

  ngOnInit(): void {
    this.listFavorites();
  }

  listFavorites(): void {
    this.loading = true;
    this.eventService.getMyFavoriteEvents().subscribe({
      next: (events) => {
        this.favoriteEvents = events;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  addFavorite(eventId: string): void {
    this.eventService.addFavorite(eventId).subscribe({
      next: () => {
        this.listFavorites();
      }
    });
  }

  removeFavorite(eventId: string): void {
    this.eventService.removeFavorite(eventId).subscribe({
      next: () => {
        this.listFavorites();
      }
    });
  }

  purchase(id: string) {
      this.eventService.get(id).subscribe(event => {
        this.selectedEvent = event;
        this.confirmation.warn('::Menu:AreYouSureToPurchase', '::Menu:AreYouSure').subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.eventService.purchaseTicket(this.selectedEvent.id, 1).subscribe(() => {
              this.listFavorites();
              this.isModalOpen = false; // Close the modal after purchase
            }, error => {
              console.error('Purchase failed', error);
            });
          }
        });
      });
    }
}
