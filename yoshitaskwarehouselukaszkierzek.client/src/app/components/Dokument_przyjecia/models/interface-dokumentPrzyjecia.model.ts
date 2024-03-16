export interface IDokumentPrzyjecia {
  id: number;
  magazynDocelowy: any;
  magazynDocelowyId: number;
  dostawca: any;
  dostawcaId: number;
  listaTowarow: IListaTowarow[];
  etykiety: IEtykiety[];
  anulowany: number;
  zatwierdzony: number;
}

interface IListaTowarow {
  id: number;
  nazwa: string;
  kod: string;
  ilosc: number;
  cena: number;
}

interface IEtykiety {
  nazwa: string;
}
