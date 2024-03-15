import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MagazynComponent} from "./components/magazyn/magazyn.component";
import {TowarListComponent} from "./components/Towar/towar-list/towar-list.component";
import {AddTowarComponent} from "./components/Towar/add-towar/add-towar.component";
import {EditTowarComponent} from "./components/Towar/edit-towar/edit-towar.component";

const routes: Routes = [
  {
    path: 'warehouse/magazyn',
    component: MagazynComponent,
  },
  {
    path: 'warehouse/towar',
    component: TowarListComponent,
  },
  {
    path: 'warehouse/towar/add',
    component: AddTowarComponent,
  },
  {
    path: 'warehouse/towar/edit/:id',
    component: EditTowarComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
