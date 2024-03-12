using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoshiTaskWarehouseLukaszKierzek.Server.Data;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Controllers
{
    [ApiController]
    [Route(WarehouseRoutes.defaultRoute)]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseContext _context;
        public WarehouseController(WarehouseContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet(WarehouseRoutes.dokumentPrzyjecia)]
        public async Task<ActionResult<IEnumerable<DokumentPrzyjecia>>> GetAllDokumentPrzyjecia()
        {
            var allDokumentyPrzyjecia = await _context.dokumentPrzyjecia
                .Include(e => e.MagazynDocelowy)
                .Include(e => e.ListaTowarow)
                .Include(e => e.Etykiety)
                .Include(e => e.ListaTowarow)
                .ToListAsync();

            return Ok(allDokumentyPrzyjecia);
        }

        [HttpGet(WarehouseRoutes.magazyn)]
        public async Task<ActionResult<IEnumerable<Magazyn>>> GetAllMagazyn()
        {
            var allMagazyny = await _context.magazyn
                .Include(e => e.DokumentyPrzyjecia)
                .ToListAsync();

            return Ok(allMagazyny);
        }

        #region Towar GET, POST, PUT, DELETE

        #region GET ALL
        [HttpGet(WarehouseRoutes.towarGET)]
        public async Task<ActionResult<IEnumerable<Towar>>> GetAllTowar()
        {
            var allToraw = await _context.towar
                .ToListAsync();

            return Ok(allToraw);
        }
        #endregion

        #region GET BY ID
        [HttpGet(WarehouseRoutes.towarById)]
        public async Task<ActionResult<Towar>> GetTowarById([FromRoute] int id)
        {
            var towarById = await _context.towar
                .FirstOrDefaultAsync(e => e.Id == id);

            if (towarById == null)
                return NotFound();

            return Ok(towarById);
        }
        #endregion

        #region POST
        [HttpPost(WarehouseRoutes.towarPOST)]
        public async Task<ActionResult<Towar>> PostTowar([FromBody] Towar newTowar)
        {
            await _context.towar.AddAsync(newTowar);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTowarById), new { id = newTowar.Id }, newTowar);
        }
        #endregion

        #region PUT
        [HttpPut(WarehouseRoutes.towarPUT)]
        public async Task<IActionResult> PutTowar([FromRoute] int id, [FromBody] Towar updateTowar)
        {
            var towar = await _context.towar
                .FirstOrDefaultAsync(e => e.Id == id);

            if (towar == null)
                return NotFound();

            if (towar.Id != id)
                return BadRequest();

            AssingTowarValuesFromBody(updateTowar, towar);

            _context.Entry(towar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var isAnyTowar = _context.towar.Any(e => e.Id == id);
                if (isAnyTowar)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();

            static void AssingTowarValuesFromBody(Towar updateTowar, Towar towar)
            {
                towar.Nazwa = updateTowar.Nazwa;
                towar.Kod = updateTowar.Kod;
                towar.DokumentPrzyjecia = updateTowar.DokumentPrzyjecia;
                towar.DokumnetPrzyjeciaId = updateTowar.DokumnetPrzyjeciaId;
                towar.Ilosc = updateTowar.Ilosc;
                towar.Cena = updateTowar.Cena;
            }
        }
        #endregion

        #region DELETE
        [HttpDelete(WarehouseRoutes.towarDELETE)]
        public async Task<IActionResult> DeleteTowar([FromRoute] int id)
        {
            var towar = await _context.towar
                .FindAsync(id);

            if (towar == null)
                return NotFound();

            _context.towar.Remove(towar);
            await _context.SaveChangesAsync();

            return NoContent();

        }
        #endregion

        #endregion

        #region Dostawca GET, POST, PUT, DELETE

        #region Dostawca GET ALL
        [HttpGet(WarehouseRoutes.dostawcaGET)]
        public async Task<ActionResult<List<Dostawca>>> GetAllDostawca()
        {
            var allDostawca = await _context.dostawca
                .ToListAsync();

            return Ok(allDostawca);
        }
        #endregion

        #region Dostawca GET BY ID
        [HttpGet(WarehouseRoutes.dostawcaById)]
        public async Task<ActionResult<Dostawca>> GetDostawcaById(int id)
        {
            var dostawcaById = await _context.dostawca
                .FirstOrDefaultAsync(e => e.Id == id);

            if (dostawcaById == null)
                return NotFound();

            return Ok(dostawcaById);
        }
        #endregion

        // TODO: Add dostawca post, put, delete
        // TODO: Add dokumenty przyjec

        #endregion

    }
}
