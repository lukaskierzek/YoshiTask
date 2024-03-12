namespace YoshiTaskWarehouseLukaszKierzek.Server.Models
{
    public class Towar
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Kod {  get; set; }
        public virtual DokumentPrzyjecia DokumentPrzyjecia { get; set; }
        public int DokumnetPrzyjeciaId { get; set;}
        public int Ilosc { get; set; }
        public decimal Cena { get; set; }
    }
}
