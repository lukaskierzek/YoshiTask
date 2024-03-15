import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

interface IMagazyn {
  id: number;
  nazwa: string;
  symbol: string;
  dokumentyPrzyjecia: any;
}

@Component({
  selector: 'app-magazyn',
  templateUrl: './magazyn.component.html',
  styleUrl: './magazyn.component.css'
})
export class MagazynComponent implements OnInit {
  public magazyn: IMagazyn[] = [];

  private magazynURL: string = 'https://localhost:7041/Warehouse/magazyn';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getMagazyn();
  }

  getMagazyn() {
    this.http.get<IMagazyn[]>(this.magazynURL).subscribe({
        next: (data: IMagazyn[]) => {
          this.magazyn = data;
          console.log(this.magazyn)
        },
        error: (error) => {
          console.log(error);
        }

      });
  }
}
