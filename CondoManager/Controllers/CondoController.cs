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
                return NotFound($"Condomínio com id {id} não encontrado");
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
                return UnprocessableEntity($"Erro ao adicionar Condomínio ${condo.Id}");
            }
            return Ok($"Condomínio {condo.Id} criado!");
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
                return NotFound($"Id {id} não é a mesma do Condomínio {condo.Name}");
            }
    
            try
            {
                await condoRepository.Update(condo);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao atualizar o Condomínio {condo.Id}");
            }
            return Ok($"Condomínio {condo.Id} atualizado!");
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
                return UnprocessableEntity($"Erro ao deletar o Condomínio {id}");
            }
            return Ok($"Condomínio {id} deletado!");
        }

        //POST: v1/api/Condo/001/AddBlock/
        [HttpPost("AddBlock")]
        public async Task<ActionResult> AddBlock(
            [FromServices]ICondoRepository condoRepository,
            [FromServices]IBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddBlockDTO fromBody)
        {
            Block Block = await condoBlockRepository.Get(fromBody.IdBlock);
            if(Block == null)
            {
                return NotFound($"Bloco com id {fromBody.IdBlock} não encontrado");
            }
            try
            {
                await condoRepository.AddBlock(fromBody.IdCondo,Block);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao adicionar o Bloco {fromBody.IdBlock} ao Condomínio {fromBody.IdCondo}");
            }
            return Ok($"Bloco {fromBody.IdBlock} adicionado ao Condomínio {fromBody.IdCondo}!");
        }

        //POST: v1/api/Block/001/RemoveBlock/
        [HttpPost("RemoveBlock")]
        public async Task<ActionResult> RemoveBlock(
            [FromServices]ICondoRepository condoRepository,
            [FromServices]IBlockRepository condoBlockRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddBlockDTO fromBody)
        {
            Block Block = await condoBlockRepository.Get(fromBody.IdBlock);
            if(Block == null)
            {
                return NotFound($"Bloco com id {fromBody.IdBlock} não encontrado");
            }
            try
            {
                await condoRepository.RemoveBlock(fromBody.IdBlock,Block);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao remover o Bloco {fromBody.IdBlock} do Condomínio {fromBody.IdCondo}");
            }
            return Ok($"Bloco {fromBody.IdBlock} removido do Condomínio {fromBody.IdCondo}!");
        }
    }
}