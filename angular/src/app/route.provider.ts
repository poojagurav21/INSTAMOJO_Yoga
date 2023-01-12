import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: './AppliedCourses',
        name: 'Applied Courses',
        iconClass: 'fas fa-home',
        layout: eLayoutType.application,       
      },
      {
        path: '/payment',
        name: '::payment',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application,
      }, 
      {
        path: '/paypal',
        name: '::paypal',
        iconClass: 'fas fa-book',
        order: 3,
        layout: eLayoutType.application,
      },   
    ]);
  };
}
