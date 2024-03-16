import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from "rxjs";
import {IPutDostawcaRequest} from "../Models/put-dostawca-request.model";
import {DostawcaService} from "../services/dostawca.service";
import {ActivatedRoute, ParamMap} from "@angular/router";

@Component({
  selector: 'app-edit-dostawcy',
  templateUrl: './edit-dostawcy.component.html',
  styleUrl: './edit-dostawcy.component.css'
})
export class EditDostawcyComponent implements OnDestroy, OnInit {
  dostawcaId: any;

  private putDostawcaSubscribtion?: Subscription;

  model: IPutDostawcaRequest;

  constructor(private dostawcaService: DostawcaService, private route: ActivatedRoute) {
    this.model = {
      nazwaFirmy: '',
      adres: ''
    }
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.dostawcaId = params.get('id')
    })
  }


  ngOnDestroy(): void {
    this.putDostawcaSubscribtion?.unsubscribe();
  }

  onFormSubmit() {
    this.putDostawcaSubscribtion = this.dostawcaService.editDostawca(this.model, this.dostawcaId)
      .subscribe({
        next: (response) => {
          alert(`Zaktualizowano ${this.model.nazwaFirmy}`)
        },
        error: (error) => {
          console.log(error);
        }
      });
  }
}
