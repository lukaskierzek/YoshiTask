import {Component} from '@angular/core';
import {Subscription} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {IDostawca} from "../Models/interface-dostawca.model";
import {DostawcaService} from "../services/dostawca.service";

@Component({
  selector: 'app-dostawcy-list',
  templateUrl: './dostawcy-list.component.html',
  styleUrl: './dostawcy-list.component.css'
})
export class DostawcyListComponent {
  public dostawca: IDostawca[] = [];

  private dostawcaURL: string = 'https://localhost:7041/Warehouse/dostawca';
  private putDostawcaSubscribtion?: Subscription;

  constructor(private http: HttpClient, private dostawcaService: DostawcaService) {
  }

  ngOnDestroy(): void {
    this.putDostawcaSubscribtion?.unsubscribe();
  }

  ngOnInit() {
    this.getTowar();
  }

  getTowar() {
    this.http.get<IDostawca[]>(this.dostawcaURL).subscribe({
      next: (data: IDostawca[]) => {
        this.dostawca = data;
        console.log(this.dostawca);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  onDeleteClick(id: number, nazwa: string) {
    let result: boolean = confirm(`Czy chcesz usunąć firmze '${nazwa}'?`);
    if (result) {
      this.putDostawcaSubscribtion = this.dostawcaService.deleteDostawca(id)
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
