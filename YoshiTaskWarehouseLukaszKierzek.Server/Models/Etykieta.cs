namespace YoshiTaskWarehouseLukaszKierzek.Server.Models
{
    public class Etykieta
    {
        public int Id { get; set; } 
        public string Nazwa { get; set; }
        public List<DokumentPrzyjecia> DokumentyPrzyjecia { get; } = [];
    }
}
