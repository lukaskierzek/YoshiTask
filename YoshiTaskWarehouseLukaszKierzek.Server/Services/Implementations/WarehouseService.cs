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
    }
}
