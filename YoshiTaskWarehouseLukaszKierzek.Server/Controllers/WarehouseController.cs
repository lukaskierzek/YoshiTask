using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoshiTaskWarehouseLukaszKierzek.Server.Data;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseContext _context;
        public WarehouseController(WarehouseContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet("dokument-przyjecia")]
        public async Task<ActionResult<IEnumerable<DokumentPrzyjecia>>> GetAllDokumentPrzyjecia()
        {
            var allDokumentyPrzyjecia = await _context.dokumentPrzyjecia
                .Include(e=>e.MagazynDocelowy)
                .Include(e=>e.ListaTowarow)
                .Include(e=>e.Etykiety)
                .Include(e=>e.ListaTowarow)
                .ToListAsync();

            return Ok(allDokumentyPrzyjecia);
        }

        [HttpGet("magazyn")]
        public async Task<ActionResult<IEnumerable<Magazyn>>> GetAllMagazyn()
        {
            var allMagazyny = await _context.magazyn
                .Include(e=>e.DokumentyPrzyjecia)
                .ToListAsync();

            return Ok(allMagazyny);
        }
    }
}
