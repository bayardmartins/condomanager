using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [Authorize]
    public class CondoBlockController : ControllerBase
    {
        //GET: v1/api/CondoBlock
        [HttpGet]
        public async Task<IEnumerable<CondoBlock>> GetAllCondoBlocks(
            [FromServices]ICondoBlockRepository condoBlockRepository)
        {
            return await condoBlockRepository.GetAll();
        }

        //GET: v1/api/CondoBlock/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CondoBlock>> GetCondoBlocksById(
            [FromServices]ICondoBlockRepository condoBlockRepository,
            int id)
        {
            var condoBlock = await condoBlockRepository.Get(id);
            if (condoBlock == null)
            {
                return NotFound();
            }
            return condoBlock;
        }

        //POST: v1/api/CondoBlock
        [HttpPost()]
        public async Task<ActionResult> CreateCondoBlock(
            [FromServices]ICondoBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            CondoBlock condoBlock)
        {
            try
            {
                await condoBlockRepository.Add(condoBlock);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //PUT: v1/api/CondoBlock/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCondoBlock(
            [FromServices]ICondoBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            int id, CondoBlock condoBlock)
        {
            if (id != condoBlock.Id)
            {
                return BadRequest();
            }
    
            try
            {
                await condoBlockRepository.Update(condoBlock);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //DELETE: v1/api/CondoBlock/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCondoBlock(
            [FromServices]ICondoBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            int id)
        {
            try
            {
                await condoBlockRepository.Delete(id);
                uow.Commit();
            }
            catch
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //POST: v1/api/CondoBlock/001/AddApartment/
        [HttpPost("AddApartment")]
        public async Task<ActionResult> AddApartment(
            [FromServices]ICondoBlockRepository condoBlockRepository,
            [FromServices]IApartmentRepository apartmentRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddApartmentDTO fromBody)
        {
            Apartment apartment = await apartmentRepository.Get(fromBody.IdApartment);
            if(apartment == null)
            {
                return NotFound();
            }
            try
            {
                await condoBlockRepository.AddApartment(fromBody.IdCondoBlock,apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //POST: v1/api/CondoBlock/001/RemoveApartment/
        [HttpPost("RemoveApartment")]
        public async Task<ActionResult> RemoveApartment(
            [FromServices]ICondoBlockRepository condoBlockRepository,
            [FromServices]IApartmentRepository apartmentRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddApartmentDTO fromBody)
        {
            Apartment apartment = await apartmentRepository.Get(fromBody.IdApartment);
            if(apartment == null)
            {
                return NotFound();
            }
            try
            {
                await condoBlockRepository.RemoveApartment(fromBody.IdCondoBlock,apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //GET: v1/api/CondoBlock/GetByBlock/1
        [HttpGet("GetByBlock/{id}")]
        public async Task<IEnumerable<CondoBlock>> GetCondoBlockByCondoId(
            [FromServices]ICondoBlockRepository condoBlockRepository,
            int id)
        {
            return condoBlockRepository.GetByCondoId(id);
        }
    }
}