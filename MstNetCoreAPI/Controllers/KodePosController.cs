using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MstNetCoreAPI.Filter;
using MstNetCoreAPI.Helpers;
using MstNetCoreAPI.Interface;
using MstNetCoreAPI.Models;
using MstNetCoreAPI.Wraper;

namespace MstNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KodePosController : ControllerBase
    {
        readonly IKodePos _kodepos;
        private readonly IUriService uriService;
        public KodePosController(IKodePos tbkodepos, IUriService uriService)
        {
            _kodepos = tbkodepos;
            this.uriService = uriService;
        }

        /// <summary>
        /// get all kode pos
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllKodePos([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedData =await _kodepos.GetKodePosList().Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();
                var totalRecords = await _kodepos.GetKodePosList().CountAsync();
                var pagedReponse = PaginationHelper.CreatePagedReponse<TbKodePosModel>(pagedData, validFilter, totalRecords, uriService, route);
                return Ok(pagedReponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get kode pos details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetKodePosById(int id)
        {
            try
            {
                var kodepos = _kodepos.GetKodePosDetailsById(id);
                if (kodepos == null) return NotFound();
                return Ok(kodepos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save kode pos
        /// </summary>
        /// <param name="kodeposModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveKodePos(TbKodePosModel kodeposModel)
        {
            try
            {
                var model = _kodepos.SaveKodePos(kodeposModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete kode pos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteKodePos(int id)
        {
            try
            {
                var model = _kodepos.DeleteKodePos(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
