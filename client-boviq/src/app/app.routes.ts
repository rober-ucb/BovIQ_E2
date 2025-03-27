import { Routes } from '@angular/router';
import { LayoutComponent } from './core/layout/layout.component';

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children:[
      {
        title: "Herds",
        path: "herds",
        loadChildren: () => import('./modules/herds/herd.routes').then(m => m.HERD_ROUTES)
      }
    ]
  },
];
