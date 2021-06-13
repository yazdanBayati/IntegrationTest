using Core;
using IntergrationTest.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntergrationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseDMSController
    {

        public ProductController(IUnitOfWorkFactory unitOfWorkFactory, IRepositoryFactory repoFactory):base(unitOfWorkFactory, repoFactory)
        {
        }
        
        
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repo = _repoFactory.Create<IFileRepository>(uow);
                var files = repo.GetAll();
                return Ok(files);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromBody] File file)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repo = _repoFactory.Create<IFileRepository>(uow);
                await repo.AddAsync(file);
                await uow.CommitAsync();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
