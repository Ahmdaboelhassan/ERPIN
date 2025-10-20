import { Routes } from '@angular/router';
import { authGuard } from './Guards/auth.guard';
import { AuthComponent } from './Components/auth/auth.component';
import { HomeComponent } from './Components/home/home.component';
import { SLInvoiceComponent } from './Components/sales/slinvoice/slinvoice.component';
import { SLReturnComponent } from './Components/sales/slreturn/slreturn.component';
import { PRInvoiceComponent } from './Components/purchases/prinvoice/prinvoice.component';
import { PRReturnComponent } from './Components/purchases/prreturn/prreturn.component';
import { CreateSlinvoiceComponent } from './Components/sales/slinvoice/create-slinvoice/create-slinvoice.component';
import { CreateSlreturnComponent } from './Components/sales/slreturn/create-slreturn/create-slreturn.component';
import { CreatePrinvoiceComponent } from './Components/purchases/prinvoice/create-prinvoice/create-prinvoice.component';
import { CreatePrreturnComponent } from './Components/purchases/prreturn/create-prreturn/create-prreturn.component';

export const routes: Routes = [
  {
    path: 'Home',
    canActivate: [authGuard],
    loadComponent: () => HomeComponent,
  },
  {
    path: 'Auth',
    loadComponent: () => AuthComponent,
  },
  {
    path: 'Sales',
    children: [
      { path: '', loadComponent: () => SLInvoiceComponent },
      { path: 'List', loadComponent: () => SLInvoiceComponent },
      { path: 'Create', loadComponent: () => CreateSlinvoiceComponent },
      { path: 'Edit/:id', loadComponent: () => CreateSlinvoiceComponent },
    ],
  },
  {
    path: 'SalesReturn',
    children: [
      { path: '', loadComponent: () => SLReturnComponent },
      { path: 'List', loadComponent: () => SLReturnComponent },
      { path: 'Create', loadComponent: () => CreateSlreturnComponent },
      { path: 'Edit/:id', loadComponent: () => CreateSlreturnComponent },
    ],
  },
  {
    path: 'Purchase',
    children: [
      { path: '', loadComponent: () => PRInvoiceComponent },
      { path: 'List', loadComponent: () => PRInvoiceComponent },
      { path: 'Create', loadComponent: () => CreatePrinvoiceComponent },
      { path: 'Edit/:id', loadComponent: () => CreatePrinvoiceComponent },
    ],
  },
  {
    path: 'PurchaseReturn',
    children: [
      { path: '', loadComponent: () => PRReturnComponent },
      { path: 'List', loadComponent: () => PRReturnComponent },
      { path: 'Create', loadComponent: () => CreatePrreturnComponent },
      { path: 'Edit/:id', loadComponent: () => CreatePrreturnComponent },
    ],
  },
  { path: '**', loadComponent: () => HomeComponent, pathMatch: 'full' },
];
