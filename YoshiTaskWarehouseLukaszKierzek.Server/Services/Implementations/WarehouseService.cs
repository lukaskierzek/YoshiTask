using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<DokumentPrzyjecia>> GetAllDokumentPrzyjecia()
        {
            var dokumentyPrzyjecia = await _context.dokumentPrzyjecia
                .Where(e => e.Anulowany == (int)IsCancelled.No)
                .Include(e => e.MagazynDocelowy)
                .Include(e => e.ListaTowarow)
                .Include(e => e.Etykiety)
                .Include(e => e.ListaTowarow)
                .ToListAsync();

            return dokumentyPrzyjecia;
        }

        public async Task<DokumentPrzyjecia> GetDokumnetPrzyjeciaById(int id)
        {
            var dokumentPrzyjeciaById = await _context.dokumentPrzyjecia
                .Where(e => e.Anulowany == (int)IsCancelled.No)
                .FirstOrDefaultAsync(e => e.Id == id);

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
            _context.dokumentPrzyjecia.Any(e => e.Id == id);

        public async Task<IEnumerable<Magazyn>> GetAllMagazyn()
        {
            var allMagazyny = await _context.magazyn
                .Include(e => e.DokumentyPrzyjecia)
                .ToListAsync();

            return allMagazyny;
        }

        public async Task<IEnumerable<Towar>> GetAllTowar()
        {
            var allTowar = await _context.towar
                            .ToListAsync();

            return allTowar;
        }

        public async Task<Towar> GetTowarById(int id)
        {
            var towarById = await _context.towar
                .FirstOrDefaultAsync(e => e.Id == id);

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
            var isAnyTowar = _context.towar.Any(e => e.Id == id);

            return isAnyTowar;
        }
    }
}
