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
                return NotFound($"Bloco com id {id} não encontrado");
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
                return UnprocessableEntity($"Erro ao adicionar bloco ${block.Id}");
            }
            return Ok($"Bloco {block.Id} criado!");
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
                return NotFound($"Id {id} não é a mesma do Bloco {block.Name}");
            }
    
            try
            {
                await condoBlockRepository.Update(block);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao atualizar o Bloco {block.Id}");
            }
            return Ok($"Bloco {block.Id} atualizado!");
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
                return UnprocessableEntity($"Erro ao deletar o Bloco {id}");
            }
            return Ok($"Bloco {id} deletado!");
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
                return NotFound($"Apartamento com id {fromBody.IdApartment} não encontrado");
            }
            try
            {
                await condoBlockRepository.AddApartment(fromBody.IdBlock,apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao adicionar o Apartamento {fromBody.IdApartment} ao Bloco {fromBody.IdBlock}");
            }
            return Ok($"Apartamento {fromBody.IdApartment} adicionado ao Bloco {fromBody.IdBlock}!");
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
                return NotFound($"Apartamento com id {fromBody.IdApartment} não encontrado");
            }
            try
            {
                await condoBlockRepository.RemoveApartment(fromBody.IdBlock,apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao adicionar o Apartamento {fromBody.IdApartment} ao Bloco {fromBody.IdBlock}");
            }
            return Ok($"Apartamento {fromBody.IdApartment} adicionado ao Bloco {fromBody.IdBlock}!");
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