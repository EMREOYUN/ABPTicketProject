import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/events',
        name: '::Menu:Events',
        iconClass: 'fas fa-calendar-alt',
        order: 2,
        layout: eLayoutType.application,
        requiredPolicy: 'ABPTicketProject.User.Events',
      },
      {
        path: '/favorites',
        name: '::Menu:Favorites',
        iconClass: 'fas fa-heart',
        order: 3,
        layout: eLayoutType.application,
        requiredPolicy: 'ABPTicketProject.User.Events',
      },
      {
        path: '/sellerlist',
        name: '::Menu:SellerList',
        iconClass: 'fas fa-calendar-alt',
        order: 4,
        layout: eLayoutType.application,
        requiredPolicy: 'ABPTicketProject.Seller',
      },
      {
        path: '/purchasedtickets',
        name: '::Menu:PurchasedTickets',
        iconClass: 'fas fa-ticket-alt',
        order: 5,
        layout: eLayoutType.application,
        requiredPolicy: 'ABPTicketProject.User.Events',
      }
  ]);
}
