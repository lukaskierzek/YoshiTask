import {Component, OnDestroy, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ITowar} from "../models/interface-towar.model";
import {Subscription} from "rxjs";
import {TowarService} from "../services/towar.service";

@Component({
  selector: 'app-towar-list',
  templateUrl: './towar-list.component.html',
  styleUrl: './towar-list.component.css'
})
export class TowarListComponent implements OnInit, OnDestroy {
  public towar: ITowar[] = [];

  private towarURL: string = 'https://localhost:7041/Warehouse/towar';
  private putTowarSubscribtion?: Subscription;

  constructor(private http: HttpClient, private towarService: TowarService) {
  }

  ngOnDestroy(): void {
    this.putTowarSubscribtion?.unsubscribe();
  }

  ngOnInit() {
    this.getTowar();
  }

  getTowar() {
    this.http.get<ITowar[]>(this.towarURL).subscribe({
      next: (data: ITowar[]) => {
        this.towar = data;
        console.log(this.towar);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  onDeleteClick(id: number, nazwa: string, kod: string) {
    let result: boolean = confirm(`Czy chcesz usunąć towar '${nazwa}' z kodem '${kod}'?`);
    if (result) {
      this.putTowarSubscribtion = this.towarService.deleteTowar(id)
        .subscribe({
          next: response => {
            alert(`Usunięto`)
          },
          error: err => {
            console.log(err);
          }
        })
    }
  }

}
