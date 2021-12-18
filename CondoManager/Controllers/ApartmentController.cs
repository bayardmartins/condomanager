using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [Authorize]
    public class ApartmentController : ControllerBase
    {
        //GET: v1/api/Apartment
        [HttpGet]
        public async Task<IEnumerable<Apartment>> GetAllApartments(
            [FromServices]IApartmentRepository apartmentRepository)
        {
            return await apartmentRepository.GetAll();
        }

        //GET: v1/api/Apartment/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Apartment>> GetApartmentsById(
            [FromServices]IApartmentRepository apartmentRepository,
            int id)
        {
            var apartment = await apartmentRepository.Get(id);
            if (apartment == null)
            {
                return NotFound($"Apartamento com id {id} não encontrado");
            }
            return apartment;
        }

        //POST: v1/api/Apartment
        [HttpPost()]
        public async Task<ActionResult> CreateApartment(
            [FromServices]IApartmentRepository apartmentRepository,
            [FromServices]IUnitOfWork uow,
            Apartment apartment)
        {
            try
            {
                await apartmentRepository.Add(apartment);
                uow.Commit();
            } 
            catch
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao adicionar Apartamento ${apartment.Id}");
            }
            return Ok($"Apartamento {apartment.Id} criado!");
        }

        //PUT: v1/api/Apartment/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateApartment(
            [FromServices]IApartmentRepository apartmentRepository,
            [FromServices]IUnitOfWork uow,
            int id, Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return NotFound($"Id {id} não é a mesma do Apartamento {apartment.Number}");
            }
    
            try
            {
                await apartmentRepository.Update(apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao atualizar o Apartamento {apartment.Id}");
            }
            return Ok($"Apartamento {apartment.Id} atualizado!");
        }

        //DELETE: v1/api/Apartment/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApartment(
            [FromServices]IApartmentRepository apartmentRepository,
            [FromServices]IUnitOfWork uow,
            int id)
        {
            try
            {
                await apartmentRepository.Delete(id);
                uow.Commit();
            }
            catch
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao deletar o Apartamento {id}");
            }
            return Ok($"Apartamento {id} deletado!");
        }

        //POST: v1/api/Apartment/001/AddResident/
        [HttpPost("AddResident")]
        public async Task<ActionResult> AddResident(
            [FromServices]IApartmentRepository apartmentRepository,
            [FromServices]IResidentRepository residentRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddResidentDTO fromBody)
        {
            Resident resident = await residentRepository.Get(fromBody.IdResident);
            if(resident == null)
            {
                return NotFound($"Residente com id {fromBody.IdResident} não encontrado");
            }
            try
            {
                await apartmentRepository.AddResident(fromBody.IdApartment,resident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao adicionar o Residente {fromBody.IdResident} ao Apartamento {fromBody.IdApartment}");
            }
            return Ok($"Residente {fromBody.IdResident} adicionado ao Apartamento {fromBody.IdApartment}!");
        }

        //POST: v1/api/Apartment/001/RemoveResident/
        [HttpPost("RemoveResident")]
        public async Task<ActionResult> RemoveResident(
            [FromServices]IApartmentRepository apartmentRepository,
            [FromServices]IResidentRepository residentRepository,
            [FromServices]IUnitOfWork uow,
            [FromBody]AddResidentDTO fromBody)
        {
            Resident resident = await residentRepository.Get(fromBody.IdResident);
            if(resident == null)
            {
                return NotFound($"Residente com id {fromBody.IdResident} não encontrado");
            }
            try
            {
                await apartmentRepository.RemoveResident(fromBody.IdApartment,resident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao remover o Residente {fromBody.IdResident} do Apartamento {fromBody.IdApartment}");;
            }
            return Ok($"Residente {fromBody.IdResident} removido do Apartamento {fromBody.IdApartment}!");
        }

        //GET: v1/api/Apartment/GetByBlock/1
        [HttpGet("GetByBlock/{id}")]
        public async Task<IEnumerable<Apartment>> GetApartmentsByBlockId(
            [FromServices]IApartmentRepository apartmentRepository,
            int id)
        {
            return apartmentRepository.GetByBlockId(id);
        }
    }
}