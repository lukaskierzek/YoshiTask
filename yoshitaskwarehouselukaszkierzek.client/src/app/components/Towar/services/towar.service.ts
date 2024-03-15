import {Injectable} from '@angular/core';
import {AddTowarRequest} from "../models/add-towar-request.model";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {PutTowarRequest} from "../models/put-towar-request.model";

@Injectable({
  providedIn: 'root'
})
export class TowarService {

  constructor(private http: HttpClient) {
  }

  addTowar(model: AddTowarRequest): Observable<void> {
    return this.http.post<void>('https://localhost:7041/Warehouse/towar', model);
  }

  editTowar(model: PutTowarRequest, id: number): Observable<void>{
    return this.http.put<void>(`https://localhost:7041/Warehouse/towar/${id}`, model);
  }

  deleteTowar(id: number): Observable<void>{
    return this.http.delete<void>(`https://localhost:7041/Warehouse/towar/${id}`);
  }
}
