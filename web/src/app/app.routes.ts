import { Routes } from '@angular/router';
import { IndexComponent } from './producto/index/index.component';

export const routes: Routes = [
    { path: '', loadComponent: () => IndexComponent }
];
