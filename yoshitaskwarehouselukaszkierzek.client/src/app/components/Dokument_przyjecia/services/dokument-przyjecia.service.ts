import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IDokumentPrzyjecia} from "../models/interface-dokumentPrzyjecia.model";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DokumentPrzyjeciaService {

  constructor(private http: HttpClient) {
  }

  getDokumentPrzyjecia(): Observable<IDokumentPrzyjecia[]> {
    return this.http.get<IDokumentPrzyjecia[]>('https://localhost:7041/Warehouse/dokument-przyjecia');
  }

  cancelDokumentPrzyjecia(id: number): Observable<void> {
    return this.http.put<void>(`https://localhost:7041/Warehouse/dokument-przyjecia/${id}`, {anulowany: 1});
  }

  confirmDokumentPrzyjecia(id: number): Observable<void> {
    return this.http.put<void>(`https://localhost:7041/Warehouse/dokument-przyjecia/${id}`, {zatwierdzony: 1});
  }
}
