namespace YoshiTaskWarehouseLukaszKierzek.Server.Models
{
    public class DokumentPrzyjecia
    {
        public int Id { get; set; }
        public virtual Magazyn? MagazynDocelowy { get; set; }
        public int? MagazynDocelowyId { get; set; }
        public virtual Dostawca? Dostawca { get; set; }
        public int? DostawcaId {  get; set; }
        public List<Towar> ListaTowarow { get; } = [];
        public List<Etykieta> Etykiety { get; } = [];
    }
}
