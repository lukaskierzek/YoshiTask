namespace YoshiTaskWarehouseLukaszKierzek.Server.Models
{
    public class DokumentPrzyjecia
    {
        public string Id { get; set; }
        public virtual Magazyn MagazynDocelowy { get; set; }
        public int MagazynDocelowyId { get; set; }
        public List<Towar> ListaTowarow { get; } = [];
        public List<Etykieta> Etykiety { get; } = [];
    }
}
