import type { CreateUpdateEventDto, EventDto, PurchasedTicketDto, SellerEventPurchaseInfoDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  apiName = 'Default';
  

  addFavorite = (eventId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/event/favorite/${eventId}`,
    },
    { apiName: this.apiName,...config });
  

  create = (input: CreateUpdateEventDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EventDto>({
      method: 'POST',
      url: '/api/app/event',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/event/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EventDto>({
      method: 'GET',
      url: `/api/app/event/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<EventDto>>({
      method: 'GET',
      url: '/api/app/event',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getMyFavoriteEvents = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, EventDto[]>({
      method: 'GET',
      url: '/api/app/event/my-favorite-events',
    },
    { apiName: this.apiName,...config });
  

  getMyPurchasedTickets = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, PurchasedTicketDto[]>({
      method: 'GET',
      url: '/api/app/event/my-purchased-tickets',
    },
    { apiName: this.apiName,...config });
  

  getSellerEventPurchaseInfo = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, SellerEventPurchaseInfoDto[]>({
      method: 'GET',
      url: '/api/app/event/seller-event-purchase-info',
    },
    { apiName: this.apiName,...config });
  

  getSellerEvents = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<EventDto>>({
      method: 'GET',
      url: '/api/app/event/seller-events',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  isFavorite = (eventId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, boolean>({
      method: 'POST',
      url: `/api/app/event/is-favorite/${eventId}`,
    },
    { apiName: this.apiName,...config });
  

  purchaseTicket = (eventId: string, quantity: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/event/purchase-ticket/${eventId}`,
      params: { quantity },
    },
    { apiName: this.apiName,...config });
  

  removeFavorite = (eventId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/event/favorite/${eventId}`,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateEventDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, EventDto>({
      method: 'PUT',
      url: `/api/app/event/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
