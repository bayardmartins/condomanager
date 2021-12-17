using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [Authorize]
    public class BlockController : ControllerBase
    {
        //GET: v1/api/Block
        [HttpGet]
        public async Task<IEnumerable<Block>> GetAllBlocks(
            [FromServices]IBlockRepository condoBlockRepository)
        {
            return await condoBlockRepository.GetAll();
        }

        //GET: v1/api/Block/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Block>> GetBlocksById(
            [FromServices]IBlockRepository condoBlockRepository,
            int id)
        {
            var block = await condoBlockRepository.Get(id);
            if (block == null)
            {
                return NotFound();
            }
            return block;
        }

        //POST: v1/api/Block
        [HttpPost()]
        public async Task<ActionResult> CreateBlock(
            [FromServices]IBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            Block block)
        {
            try
            {
                await condoBlockRepository.Add(block);
                uow.Commit();
            } 
            catch
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //PUT: v1/api/Block/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlock(
            [FromServices]IBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            int id, Block block)
        {
            if (id != block.Id)
            {
                return BadRequest();
            }
    
            try
            {
                await condoBlockRepository.Update(block);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //DELETE: v1/api/Block/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlock(
            [FromServices]IBlockRepository condoBlockRepository,
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

        //POST: v1/api/Block/001/AddApartment/
        [HttpPost("AddApartment")]
        public async Task<ActionResult> AddApartment(
            [FromServices]IBlockRepository condoBlockRepository,
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
                await condoBlockRepository.AddApartment(fromBody.IdBlock,apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //POST: v1/api/Block/001/RemoveApartment/
        [HttpPost("RemoveApartment")]
        public async Task<ActionResult> RemoveApartment(
            [FromServices]IBlockRepository condoBlockRepository,
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
                await condoBlockRepository.RemoveApartment(fromBody.IdBlock,apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
        }

        //GET: v1/api/Block/GetByCondo/1
        [HttpGet("GetByCondo/{id}")]
        public async Task<IEnumerable<Block>> GetBlockByCondoId(
            [FromServices]IBlockRepository condoBlockRepository,
            int id)
        {
            return condoBlockRepository.GetByCondoId(id);
        }
    }
}