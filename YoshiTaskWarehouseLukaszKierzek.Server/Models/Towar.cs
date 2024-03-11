namespace YoshiTaskWarehouseLukaszKierzek.Server.Models
{
    public class Towar
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Kod {  get; set; }
        public DokumentPrzyjecia DokumentPrzyjecia { get; set; }
        public int DokumnetPrzyjeciaId { get; set;}
    }
}
