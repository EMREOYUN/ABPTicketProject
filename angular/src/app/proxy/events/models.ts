import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';

export interface CreateUpdateEventDto {
  name: string;
  ageRestriction: boolean;
  description: string;
  price: number;
  date: string;
  location: string;
  imageURL: string;
  quota: number;
  userQuota: number;
  active: boolean;
}

export interface EventDto extends AuditedEntityDto<string> {
  name?: string;
  ageRestriction: boolean;
  price: number;
  date?: string;
  location?: string;
  description?: string;
  imageURL?: string;
  quota: number;
  userQuota: number;
  active: boolean;
}

export interface PurchasedTicketDto extends EntityDto<string> {
  userId?: string;
  eventId?: string;
  quantity: number;
  purchaseDate?: string;
}
