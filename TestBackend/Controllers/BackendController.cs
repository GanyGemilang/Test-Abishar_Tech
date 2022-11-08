using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBackend.Models;
using TestBackend.Repositories;
using TestBackend.ViewModels;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackendController : ControllerBase
    {
        public readonly LogicRepository logicRepository;
        public BackendController(LogicRepository logicRepository)
        {
            this.logicRepository = logicRepository;
        }


        [HttpPost("InsertData")]
        public IActionResult InsertData(InsertDataVm trBpkb)
        {
            try
            {
                if (trBpkb == null)
                {
                    return StatusCode(400, new { Code = "400", Status = "False", Message = "Data Tidak Boleh Null", Data = trBpkb });
                }

                var logic = logicRepository.InsertData(trBpkb);
                if (logic > 0)
                {
                    return Ok(new { Code = "200", Status = "True", Message = "Berhasil Insert Data", Data = trBpkb });
                }
                else
                {
                    return NotFound(new { Code = "404", Status = "False", Message = "Gagal Insert Data", Data = trBpkb });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = "500", Status = "False", Message = e.Message, Data = "Null" });
            }
        }

        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            try
            {
                var logic = logicRepository.GetUser();
                if (logic.Count() > 0)
                {
                    return Ok(new { Code = "200", Status = "True", Message = "Berhasil Get Data", Data = logic });
                }
                else
                {
                    return NotFound(new { Code = "404", Status = "False", Message = "Gagal Get Data", Data = "Null" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = "500", Status = "False", Message = e.Message, Data = "Null" });
            }
        }
    }
}
