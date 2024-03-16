import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavbarComponent} from './components/navbar/navbar.component';
import {MagazynComponent} from './components/magazyn/magazyn.component';
import {TowarListComponent} from './components/Towar/towar-list/towar-list.component';
import {AddTowarComponent} from './components/Towar/add-towar/add-towar.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { EditTowarComponent } from './components/Towar/edit-towar/edit-towar.component';
import { DokumentPrzyjeciaListComponent } from './components/Dokument_przyjecia/dokument-przyjecia-list/dokument-przyjecia-list.component';
import {DostawcyListComponent} from "./components/dostawcy/dostawcy-list/dostawcy-list.component";
import { AddDostawcyComponent } from './components/dostawcy/add-dostawcy/add-dostawcy.component';
import { EditDostawcyComponent } from './components/dostawcy/edit-dostawcy/edit-dostawcy.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    MagazynComponent,
    TowarListComponent,
    AddTowarComponent,
    EditTowarComponent,
    DokumentPrzyjeciaListComponent,
    DostawcyListComponent,
    AddDostawcyComponent,
    EditDostawcyComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
