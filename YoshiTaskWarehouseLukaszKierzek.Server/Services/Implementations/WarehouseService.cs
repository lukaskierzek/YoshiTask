using Microsoft.EntityFrameworkCore;
using YoshiTaskWarehouseLukaszKierzek.Server.Data;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;
using YoshiTaskWarehouseLukaszKierzek.Server.Models.Enums;
using YoshiTaskWarehouseLukaszKierzek.Server.Services.Interfaces;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Services.Implementations
{
    public class WarehouseService : IWarehouseService
    {
        private readonly WarehouseContext _context;

        public WarehouseService(WarehouseContext dbContext)
        {
            _context = dbContext;
        }

        #region DokumentPrzyjecia

        public async Task<IEnumerable<DokumentPrzyjecia>> GetAllDokumentPrzyjecia()
        {
            var dokumentyPrzyjecia = await _context.dokumentPrzyjecia
                .Where(dokumentyPrzyjecia => dokumentyPrzyjecia.Anulowany == (int)IsCancelled.No)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.MagazynDocelowy)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.Dostawca)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.ListaTowarow)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.Etykiety)
                .ToListAsync();

            return dokumentyPrzyjecia;
        }

        public async Task<DokumentPrzyjecia> GetDokumnetPrzyjeciaById(int id)
        {
            var dokumentPrzyjeciaById = await _context.dokumentPrzyjecia
                .Where(dokumentyPrzyjecia => dokumentyPrzyjecia.Anulowany == (int)IsCancelled.No)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.MagazynDocelowy)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.Dostawca)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.ListaTowarow)
                .Include(dokumentyPrzyjecia => dokumentyPrzyjecia.Etykiety)
                .FirstOrDefaultAsync(dokumentyPrzyjecia => dokumentyPrzyjecia.Id == id);

            return dokumentPrzyjeciaById;
        }

        public async Task<DokumentPrzyjecia> PostDokumentPrzyjecia(DokumentPrzyjecia dokumentPrzyjecia)
        {
            await _context.dokumentPrzyjecia.AddAsync(dokumentPrzyjecia);
            await _context.SaveChangesAsync();

            return dokumentPrzyjecia;
        }

        public async Task<DokumentPrzyjecia> PutDokumentPrzyjeciaSave(DokumentPrzyjecia dokumentPrzyjecia)
        {
            _context.Entry(dokumentPrzyjecia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return dokumentPrzyjecia;
        }

        public bool AnyDokuemntPrzyjecia(int id) =>
            _context.dokumentPrzyjecia.Any(dokumentyPrzyjecia => dokumentyPrzyjecia.Id == id);

        #endregion

        #region Magazyn

        public async Task<IEnumerable<Magazyn>> GetAllMagazyn()
        {
            var allMagazyny = await _context.magazyn
                .Include(magazyn => magazyn.DokumentyPrzyjecia)
                .ToListAsync();

            return allMagazyny;
        }

        #endregion

        #region Towar

        public async Task<IEnumerable<Towar>> GetAllTowar()
        {
            var allTowar = await _context.towar
                            .ToListAsync();

            return allTowar;
        }

        public async Task<Towar> GetTowarById(int id)
        {
            var towarById = await _context.towar
                .FirstOrDefaultAsync(towar => towar.Id == id);

            return towarById;
        }

        public async Task<Towar> PostTowar(Towar towar)
        {
            await _context.towar.AddAsync(towar);
            await _context.SaveChangesAsync();

            return towar;
        }

        public async Task<Towar> PutTowar(Towar towar)
        {
            _context.Entry(towar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return towar;
        }

        public async Task<Towar> FindTowarToDelete(int id)
        {
            var towar = await _context.towar
                .FindAsync(id);

            return towar;
        }

        public async Task<Towar> DeleteTowar(Towar towar)
        {
            _context.towar.Remove(towar);
            await _context.SaveChangesAsync();

            return towar;
        }

        public bool AnyTowar(int id)
        {
            var isAnyTowar = _context.towar.Any(towar => towar.Id == id);

            return isAnyTowar;
        }

        #endregion

        #region Dostawca

        public async Task<IEnumerable<Dostawca>> GetAllDostawca()
        {
            var allDostawca = await _context.dostawca
                .Include(dostawca => dostawca.DokumentyPrzyjecia)
                .ToListAsync();

            return allDostawca;
        }

        public async Task<Dostawca> GetDostawcaById(int id)
        {
            var dostawcaById = await _context.dostawca
                .Include(dostawca => dostawca.DokumentyPrzyjecia)
                .FirstOrDefaultAsync(dostawca => dostawca.Id == id);

            return dostawcaById;
        }

        public async Task<Dostawca> PostDostawca(Dostawca dostawca)
        {
            await _context.dostawca.AddAsync(dostawca);
            await _context.SaveChangesAsync();

            return dostawca;
        }

        public async Task<Dostawca> PutDostawca(Dostawca dostawca)
        {
            _context.Entry(dostawca).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return dostawca;
        }

        public async Task<Dostawca> FindDostawcaToDelete(int id)
        {
            var dostawca = await _context.dostawca
                .FindAsync(id);

            return dostawca;
        }

        public async Task<Dostawca> DeleteDostawca(Dostawca dostawca)
        {
            _context.dostawca.Remove(dostawca);
            await _context.SaveChangesAsync();

            return dostawca;
        }

        public bool AnyDostawca(int id)
        {
            var isAnyDostawca = _context.dostawca.Any(dostawca => dostawca.Id == id);

            return isAnyDostawca;
        }

        #endregion
    }
}
