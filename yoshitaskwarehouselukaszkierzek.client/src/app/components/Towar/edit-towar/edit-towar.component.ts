import {Component, OnDestroy, OnInit} from '@angular/core';
import {ITowar} from "../models/interface-towar.model";
import {HttpClient} from "@angular/common/http";
import {Subscription} from "rxjs";
import {TowarService} from "../services/towar.service";
import {IPutTowarRequest} from "../models/put-towar-request.model";
import {ActivatedRoute, ParamMap} from "@angular/router";

@Component({
  selector: 'app-edit-towar',
  templateUrl: './edit-towar.component.html',
  styleUrl: './edit-towar.component.css'
})
export class EditTowarComponent implements OnInit, OnDestroy {
  public towarById: ITowar[] = [];
  towarId: any;
  towarDetail: ITowar | undefined;

  private putTowarSubscribtion?: Subscription;

  model: IPutTowarRequest;

  constructor(private http: HttpClient, private towarService: TowarService, private route: ActivatedRoute) {
    this.model = {
      nazwa: this.towarDetail?.nazwa,
      kod: '',
      dokumnetPrzyjeciaId: 0,
      ilosc: 0,
      cena: 0,
    }
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.towarId = params.get('id')
    })

    this.getTowarById(this.towarId);
  }

  ngOnDestroy(): void {
    this.putTowarSubscribtion?.unsubscribe();
  }

  getTowarById(id: number) {
    this.http.get<ITowar[]>(`https://localhost:7041/Warehouse/towar`).subscribe({
      next: (data: ITowar[]) => {
        this.towarById = data;
        console.log(this.towarById)
        this.towarDetail = this.towarById.find(t=>t.id == this.towarId);
        console.log(this.towarDetail);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  onFormSubmit() {
    this.putTowarSubscribtion = this.towarService.editTowar(this.model, this.towarId)
      .subscribe({
        next: (response) => {
          alert(`Zaktualizowano ${this.model.nazwa}`)
        },
        error: (error) => {
          console.log(error);
        }
      });
  }
}
