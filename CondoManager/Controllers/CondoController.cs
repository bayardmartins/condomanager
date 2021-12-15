using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [Authorize]

    public class CondoController : ControllerBase
    {
        //GET: v1/api/Condo
        [HttpGet]
        public async Task<IEnumerable<Condo>> GetAllCondo(
            [FromServices]ICondoRepository condoRepository)
        {
            return await condoRepository.GetAll();
        }

        //GET: v1/api/Condo/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Condo>> GetCondoById(
            [FromServices]ICondoRepository condoRepository,
            int id)
        {
            var condo = await condoRepository.Get(id);
            if (condo == null)
            {
                return NotFound();
            }
            return condo;
        }

        //POST: v1/api/Condo
        [HttpPost()]
        public async Task<ActionResult> CreateCondo(
            [FromServices]ICondoRepository condoRepository,
            [FromServices]IUnitOfWork uow,
            Condo condo)
        {
            try
            {
                await condoRepository.Add(condo);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //PUT: v1/api/Condo/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCondo(
            [FromServices]ICondoRepository condoRepository,
            [FromServices]IUnitOfWork uow,
            int id, Condo condo)
        {
            if (id != condo.Id)
            {
                return BadRequest();
            }
    
            try
            {
                await condoRepository.Update(condo);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //DELETE: v1/api/Condo/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCondo(
            [FromServices]ICondoRepository condoRepository,
            [FromServices]IUnitOfWork uow,
            int id)
        {
            try
            {
                await condoRepository.Delete(id);
                uow.Commit();
            }
            catch
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //POST: v1/api/Condo/001/AddCondoBlock/
        [HttpPost("AddCondoBlock")]
        public async Task<ActionResult> AddCondoBlock(
            [FromServices]ICondoRepository condoRepository,
            [FromServices]ICondoBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddBlockDTO fromBody)
        {
            CondoBlock CondoBlock = await condoBlockRepository.Get(fromBody.IdCondoBlock);
            if(CondoBlock == null)
            {
                return NotFound();
            }
            try
            {
                await condoRepository.AddBlock(fromBody.IdCondo,CondoBlock);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //POST: v1/api/CondoBlock/001/RemoveCondoBlock/
        [HttpPost("RemoveCondoBlock")]
        public async Task<ActionResult> RemoveCondoBlock(
            [FromServices]ICondoRepository condoRepository,
            [FromServices]ICondoBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddBlockDTO fromBody)
        {
            CondoBlock CondoBlock = await condoBlockRepository.Get(fromBody.IdCondoBlock);
            if(CondoBlock == null)
            {
                return NotFound();
            }
            try
            {
                await condoRepository.RemoveBlock(fromBody.IdCondoBlock,CondoBlock);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }
    }
}