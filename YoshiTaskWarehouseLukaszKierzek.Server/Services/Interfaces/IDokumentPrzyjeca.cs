using YoshiTaskWarehouseLukaszKierzek.Server.Models;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Services.Interfaces
{
    public interface IDokumentPrzyjeca
    {
        Task<IEnumerable<DokumentPrzyjecia>> GetAllDokumentPrzyjecia();
        Task<DokumentPrzyjecia> GetDokumnetPrzyjeciaById(int id);
        Task<DokumentPrzyjecia> PostDokumentPrzyjecia(DokumentPrzyjecia dokumentPrzyjecia);
        Task<DokumentPrzyjecia> PutDokumentPrzyjeciaSave(DokumentPrzyjecia dokumentPrzyjecia);
        bool AnyDokuemntPrzyjecia(int id);
    }
}
