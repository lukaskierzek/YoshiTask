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

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    MagazynComponent,
    TowarListComponent,
    AddTowarComponent,
    EditTowarComponent
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
