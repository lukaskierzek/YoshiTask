import {Component, OnDestroy} from '@angular/core';
import {AddTowarRequest} from "../models/add-towar-request.model";
import {TowarService} from "../services/towar.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-add-towar',
  templateUrl: './add-towar.component.html',
  styleUrl: './add-towar.component.css'
})
export class AddTowarComponent implements OnDestroy{

  model: AddTowarRequest;
  private addTowarSubscribtion?: Subscription;

  constructor(private towarService: TowarService ) {
    this.model = {
      nazwa: '',
      kod: ''
    }
  }

  ngOnDestroy(): void {
        this.addTowarSubscribtion?.unsubscribe();
    }

  onFormSubmit(){
    this.addTowarSubscribtion =  this.towarService.addTowar(this.model)
      .subscribe({
        next: (response) => {
          alert(`Dodano ${this.model.nazwa}`)
        },
        error: (error) => {
          console.log(error);
        }
      });
  }
}
