namespace YoshiTaskWarehouseLukaszKierzek.Server.Models
{
    public class Dostawca
    {
        public int Id { get; set; }
        public string NazwaFirmy { get; set; }
        public string Adres { get; set; }
        public virtual List<DokumentPrzyjecia> DokumentyPrzyjecia { get; } = [];
    }
}
