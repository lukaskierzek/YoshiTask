import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ITowar} from "../models/interface-towar.model";

@Component({
  selector: 'app-towar-list',
  templateUrl: './towar-list.component.html',
  styleUrl: './towar-list.component.css'
})
export class TowarListComponent implements OnInit {
  public towar: ITowar[] = [];
  private towarURL: string = 'https://localhost:7041/Warehouse/towar';
  public towarId: number = 0;

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getTowar();
  }

  getTowar() {
    this.http.get<ITowar[]>(this.towarURL).subscribe({
      next: (data: ITowar[]) => {
        this.towar = data;
        console.log(this.towar)
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  onDeleteClick(nazwa: string, kod: string) {
    let result: boolean = confirm(`Czy chcesz usunąć towar '${nazwa}' z kodem '${kod}'?`);
    if (result){
      alert("wywalono!")
    }
  }

}
