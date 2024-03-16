import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MagazynComponent} from "./components/magazyn/magazyn.component";
import {TowarListComponent} from "./components/Towar/towar-list/towar-list.component";
import {AddTowarComponent} from "./components/Towar/add-towar/add-towar.component";
import {EditTowarComponent} from "./components/Towar/edit-towar/edit-towar.component";
import {
  DokumentPrzyjeciaListComponent
} from "./components/Dokument_przyjecia/dokument-przyjecia-list/dokument-przyjecia-list.component";
import {DostawcyListComponent} from "./components/dostawcy/dostawcy-list/dostawcy-list.component";
import {AddDostawcyComponent} from "./components/dostawcy/add-dostawcy/add-dostawcy.component";
import {EditDostawcyComponent} from "./components/dostawcy/edit-dostawcy/edit-dostawcy.component";

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
  },
  {
    path: 'warehouse/dokument-przyjecia',
    component: DokumentPrzyjeciaListComponent,
  },
  {
    path: 'warehouse/dostawca',
    component: DostawcyListComponent,
  },
  {
    path: 'warehouse/dostawca/add',
    component: AddDostawcyComponent,
  },
  {
    path: 'warehouse/dostawca/edit/:id',
    component: EditDostawcyComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
