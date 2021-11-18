using CoreMicroservice.Model;
using CoreMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CoreMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadicatorController : ControllerBase
    {
        private readonly IRadicatorRepository _radicatorRepository;

        public RadicatorController(IRadicatorRepository radicatorRepository)
        {
            _radicatorRepository = radicatorRepository;
        }

        /// <summary>
        /// GetRegisterFiles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<RegisterFile>> Get()
        {
            var accounts = _radicatorRepository.GetRegisterFiles();
            return Ok(accounts);
        }

        /// <summary>
        /// GetRegisterFile by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<RegisterFile> Get(Guid id)
        {
            var registerFile = _radicatorRepository.GetRegisterFile(id);
            return Ok(registerFile);
        }

        /// <summary>
        /// InsertRegisterFile
        /// </summary>
        /// <param name="registerFile"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] RegisterFile registerFile)
        {
            registerFile.RegisterDate = DateTime.Now;
            _radicatorRepository.InsertRegisterFile(registerFile);
            return CreatedAtAction(nameof(Get), new { id = registerFile.Id }, registerFile);
        }

        /// <summary>
        /// UpdateRegisterFile
        /// </summary>
        /// <param name="registerFile"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put([FromBody] RegisterFile registerFile)
        {
            if (registerFile != null)
            {
                _radicatorRepository.UpdateRegisterFile(registerFile);
                return new OkResult();
            }
            return new NoContentResult();
        }

        /// <summary>
        /// DeleteRegisterFile by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _radicatorRepository.DeleteRegisterFile(id);
            return new OkResult();
        }
    }
}
