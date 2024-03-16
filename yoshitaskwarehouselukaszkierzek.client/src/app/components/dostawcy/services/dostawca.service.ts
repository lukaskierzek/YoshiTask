import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {IAddDostawcaRequest} from "../Models/add-dostawca-request.model";
import {IPutDostawcaRequest} from "../Models/put-dostawca-request.model";

@Injectable({
  providedIn: 'root'
})
export class DostawcaService {

  constructor(private http: HttpClient) {
  }

  addDostawca(model: IAddDostawcaRequest): Observable<void> {
    return this.http.post<void>('https://localhost:7041/Warehouse/dostawca', model);
  }

  editDostawca(model: IPutDostawcaRequest, id: number): Observable<void> {
    return this.http.put<void>(`https://localhost:7041/Warehouse/dostawca/${id}`, model);
  }

  deleteDostawca(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:7041/Warehouse/dostawca/${id}`);
  }
}
