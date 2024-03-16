import {Component, OnDestroy} from '@angular/core';
import {Subscription} from "rxjs";
import {IAddDostawcaRequest} from "../Models/add-dostawca-request.model";
import {DostawcaService} from "../services/dostawca.service";

@Component({
  selector: 'app-add-dostawcy',
  templateUrl: './add-dostawcy.component.html',
  styleUrl: './add-dostawcy.component.css'
})
export class AddDostawcyComponent implements OnDestroy {
  model: IAddDostawcaRequest;
  private addDostawcaSubscribtion?: Subscription;

  constructor(private dostawcaService: DostawcaService) {
    this.model = {
      nazwaFirmy: '',
      adres: ''
    }
  }

  ngOnDestroy(): void {
    this.addDostawcaSubscribtion?.unsubscribe();
  }

  onFormSubmit() {
    this.addDostawcaSubscribtion = this.dostawcaService.addDostawca(this.model)
      .subscribe({
        next: (response) => {
          alert(`Dodano ${this.model.nazwaFirmy}`)
        },
        error: (error) => {
          console.log(error);
        }
      });
  }
}
