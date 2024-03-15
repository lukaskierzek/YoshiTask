using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoshiTaskWarehouseLukaszKierzek.Server.Data;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;
using YoshiTaskWarehouseLukaszKierzek.Server.Services.Interfaces;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Controllers
{
    [ApiController]
    [Route(WarehouseRoutes.defaultRoute)]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        #region DokumentPrzyjecia GET, POST, PUT

        [HttpGet(WarehouseRoutes.dokumentPrzyjeciaGET)]
        public async Task<ActionResult<IEnumerable<DokumentPrzyjecia>>> GetAllDokumentPrzyjecia()
        {
            var allDokumentyPrzyjecia = await _warehouseService.GetAllDokumentPrzyjecia();

            return Ok(allDokumentyPrzyjecia);
        }

        [HttpGet(WarehouseRoutes.dokumentPrzyjeciaById)]
        public async Task<ActionResult<DokumentPrzyjecia>> GetDokumnetPrzyjeciaById([FromRoute] int id)
        {
            var dokumentPrzyjeciaById = await _warehouseService.GetDokumnetPrzyjeciaById(id);

            if (dokumentPrzyjeciaById == null)
                return NotFound();

            return Ok(dokumentPrzyjeciaById);
        }

        [HttpPost(WarehouseRoutes.dokumentPrzyjeciaPOST)]
        public async Task<ActionResult<DokumentPrzyjecia>> PostDokumentPrzyjecia([FromBody] DokumentPrzyjecia newDokumentPrzyjecia)
        {
            await _warehouseService.PostDokumentPrzyjecia(newDokumentPrzyjecia);

            return CreatedAtAction(nameof(GetDokumnetPrzyjeciaById), new { id = newDokumentPrzyjecia.Id }, newDokumentPrzyjecia);
        }

        [HttpPut(WarehouseRoutes.dokumentPrzyjeciaPUT)]
        public async Task<IActionResult> PutDokumentPrzyjecia([FromRoute] int id, [FromBody] DokumentPrzyjecia updateDokumentPrzyjecia)
        {
            var dokumentPrzyjecia = await _warehouseService.GetDokumnetPrzyjeciaById(id);

            if (dokumentPrzyjecia == null)
                return NotFound();

            if (dokumentPrzyjecia.Id != id)
                return BadRequest();

            AssignDokumentPrzyjeciaValuesFromBody(dokumentPrzyjecia, updateDokumentPrzyjecia);

            try
            {
                await _warehouseService.PutDokumentPrzyjeciaSave(dokumentPrzyjecia);
            }
            catch (DbUpdateConcurrencyException)
            {
                var IsAnyDokumentPrzyjecia = _warehouseService.AnyDokuemntPrzyjecia(id);
                if (IsAnyDokumentPrzyjecia)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();

            static void AssignDokumentPrzyjeciaValuesFromBody(DokumentPrzyjecia dokumentPrzyjecia, DokumentPrzyjecia updateDokumentPrzyjecia)
            {
                dokumentPrzyjecia.MagazynDocelowyId = updateDokumentPrzyjecia.MagazynDocelowyId;
                dokumentPrzyjecia.DostawcaId = updateDokumentPrzyjecia.DostawcaId;
                dokumentPrzyjecia.Anulowany = updateDokumentPrzyjecia.Anulowany;
                dokumentPrzyjecia.Zatwierdzony = updateDokumentPrzyjecia.Zatwierdzony;
            }
        }

        #endregion

        #region Magazyn GET

        [HttpGet(WarehouseRoutes.magazyn)]
        public async Task<ActionResult<IEnumerable<Magazyn>>> GetAllMagazyn()
        {
            var allMagazyny = await _warehouseService.GetAllMagazyn();

            return Ok(allMagazyny);
        }

        #endregion

        #region Towar GET, POST, PUT, DELETE

        #region GET ALL
        [HttpGet(WarehouseRoutes.towarGET)]
        public async Task<ActionResult<IEnumerable<Towar>>> GetAllTowar()
        {
            var allTowar = await _warehouseService.GetAllTowar();

            return Ok(allTowar);
        }
        #endregion

        #region GET BY ID
        [HttpGet(WarehouseRoutes.towarById)]
        public async Task<ActionResult<Towar>> GetTowarById([FromRoute] int id)
        {
            var towarById = await _warehouseService.GetTowarById(id);

            if (towarById == null)
                return NotFound();

            return Ok(towarById);
        }
        #endregion

        #region POST
        [HttpPost(WarehouseRoutes.towarPOST)]
        public async Task<ActionResult<Towar>> PostTowar([FromBody] Towar newTowar)
        {
            await _warehouseService.PostTowar(newTowar);

            return CreatedAtAction(nameof(GetTowarById), new { id = newTowar.Id }, newTowar);
        }
        #endregion

        #region PUT
        [HttpPut(WarehouseRoutes.towarPUT)]
        public async Task<IActionResult> PutTowar([FromRoute] int id, [FromBody] Towar updateTowar)
        {
            var towar = await _warehouseService.GetTowarById(id);

            if (towar == null)
                return NotFound();

            if (towar.Id != id)
                return BadRequest();

            AssignTowarValuesFromBody(updateTowar, towar);

            try
            {
                await _warehouseService.PutTowar(towar);
            }
            catch (DbUpdateConcurrencyException)
            {
                var isAnyTowar = _warehouseService.AnyTowar(id);
                if (isAnyTowar)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();

            static void AssignTowarValuesFromBody(Towar updateTowar, Towar towar)
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
            var towar = await _warehouseService.FindTowarToDelete(id);

            if (towar == null)
                return NotFound();

            await _warehouseService.DeleteTowar(towar);

            return NoContent();
        }
        #endregion

        #endregion

        #region Dostawca GET, POST, PUT, DELETE

        #region Dostawca GET ALL
        [HttpGet(WarehouseRoutes.dostawcaGET)]
        public async Task<ActionResult<List<Dostawca>>> GetAllDostawca()
        {
            var allDostawca = await _warehouseService.GetAllDostawca();

            return Ok(allDostawca);
        }
        #endregion

        #region Dostawca GET BY ID
        [HttpGet(WarehouseRoutes.dostawcaById)]
        public async Task<ActionResult<Dostawca>> GetDostawcaById(int id)
        {
            var dostawcaById = await _warehouseService.GetDostawcaById(id);

            if (dostawcaById == null)
                return NotFound();

            return Ok(dostawcaById);
        }
        #endregion

        #region Dostawca POST
        [HttpPost(WarehouseRoutes.dostawcaPOST)]
        public async Task<ActionResult<Dostawca>> PostDostawca([FromBody] Dostawca newDostawca)
        {
            await _warehouseService.PostDostawca(newDostawca);

            return CreatedAtAction(nameof(GetDostawcaById), new { id = newDostawca.Id }, newDostawca);
        }
        #endregion

        #region Dostawca PUT
        [HttpPut(WarehouseRoutes.dostawcaPUT)]
        public async Task<IActionResult> PutDostawca([FromRoute] int id, [FromBody] Dostawca updateDostawca)
        {
            var dostawca = await _warehouseService.GetDostawcaById(id);

            if (dostawca == null)
                return NotFound();

            if (dostawca.Id != id)
                return BadRequest();

            AssignDostawcaValuesFromBody(dostawca, updateDostawca);

            static void AssignDostawcaValuesFromBody(Dostawca dostawca, Dostawca updateDostawca)
            {
                //dostawca.Id = updateDostawca.Id;
                dostawca.NazwaFirmy = updateDostawca.NazwaFirmy;
                dostawca.Adres = updateDostawca.Adres;
                //dostawca.DokumentyPrzyjecia = updateDostawca.DokumentyPrzyjecia;
            }

            try
            {
                await _warehouseService.PutDostawca(dostawca);
            }
            catch (DbUpdateConcurrencyException)
            {
                var isAnyDostawca = _warehouseService.AnyDostawca(id);
                if (isAnyDostawca)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }
        #endregion

        #region Dostawca DELETE
        [HttpDelete(WarehouseRoutes.dostawcaDELETE)]
        public async Task<ActionResult<Dostawca>> DeleteDostawca([FromRoute] int id)
        {
            var dostawca = await _warehouseService.FindDostawcaToDelete(id);

            if (dostawca == null)
                return NotFound();

            await _warehouseService.DeleteDostawca(dostawca);

            return NoContent();
        }
        #endregion

        #endregion
    }
}
