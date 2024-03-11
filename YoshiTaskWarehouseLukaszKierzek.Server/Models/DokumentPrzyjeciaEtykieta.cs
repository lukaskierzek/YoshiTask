namespace YoshiTaskWarehouseLukaszKierzek.Server.Models
{
    public class DokumentPrzyjeciaEtykieta
    {
        public int DokumentPrzyjeciaId { get; set; }
        public int EtykietaId { get; set; }
        public virtual DokumentPrzyjecia DokumentPrzyjecia { get; set; }
        public virtual Etykieta Etykieta { get; set; }
    }
}
