import {Component, OnDestroy, OnInit} from '@angular/core';
import {Subscription} from "rxjs";
import {IDokumentPrzyjecia} from "../models/interface-dokumentPrzyjecia.model";
import {DokumentPrzyjeciaService} from "../services/dokument-przyjecia.service";

@Component({
  selector: 'app-dokument-przyjecia-list',
  templateUrl: './dokument-przyjecia-list.component.html',
  styleUrl: './dokument-przyjecia-list.component.css'
})
export class DokumentPrzyjeciaListComponent implements OnInit, OnDestroy {
  public dokumnetPrzyjecia: IDokumentPrzyjecia[] = []

  private cancelDokumentPrzyjecia?: Subscription;
  private confirmDokumentPrzyjecia?: Subscription;

  constructor(private dokumentPrzyjeciaService: DokumentPrzyjeciaService) {
  }

  ngOnInit(): void {
    this.getDokumentPrzyjecia();
  }

  ngOnDestroy(): void {
    this.cancelDokumentPrzyjecia?.unsubscribe();
    this.confirmDokumentPrzyjecia?.unsubscribe();
  }

  getDokumentPrzyjecia(): void {
    this.dokumentPrzyjeciaService.getDokumentPrzyjecia().subscribe({
      next: (data: IDokumentPrzyjecia[]): void => {
        this.dokumnetPrzyjecia = data;
        console.log((this.dokumnetPrzyjecia));
      },
      error: err => {
        console.error(err);
      }
    });
  }

  onCancelClick(id: number) {
    let result: boolean = confirm(`Czy chcesz anulować dokument przyjęcia'?`);
    if (result) {
      this.cancelDokumentPrzyjecia = this.dokumentPrzyjeciaService.cancelDokumentPrzyjecia(id)
        .subscribe({
          next: response => {
            alert(`Anulowano!`)
          },
          error: err => {
            console.log(err);
          }
        })
    }
  }

  onConfirmClick(id: number) {
    let result: boolean = confirm(`Czy chcesz zatwierdzić dokument przyjęcia'?`);
    if (result) {
      this.confirmDokumentPrzyjecia = this.dokumentPrzyjeciaService.confirmDokumentPrzyjecia(id)
        .subscribe({
          next: response => {
            alert(`Zatwierdzono!`)
          },
          error: err => {
            console.log(err);
          }
        })
    }
  }

}
