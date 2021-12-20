using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CondoManager.Services;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    [Authorize]
    public class ResidentController : ControllerBase
    {
        ResidentService residenceService;

        public ResidentController() : base() {
            residenceService = new ResidentService();
        }

        //GET: v1/api/Resident
        [HttpGet]
        public async Task<IEnumerable<Resident>> GetAllResidents(
            [FromServices]IResidentRepository residentRepository)
        {
            return await residentRepository.GetAll();
        }

        //GET: v1/api/Resident/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResidentById(
            [FromServices]IResidentRepository residentRepository,
            int id)
        {
            var resident = await residentRepository.Get(id);
            if (resident == null)
            {
                return NotFound($"Residente com id {id} não encontrado");
            }
            return resident;
        }

        //POST: v1/api/Resident
        [HttpPost()]
        public async Task<ActionResult> CreateResident(
            [FromServices]IResidentRepository residentRepository,
            [FromServices]IUnitOfWork uow,
            Resident resident)
        {
            Resident newResident = residenceService.CreateResident(resident);
            //Postgres exige utc explícito
            newResident.BirthDay = DateTime.SpecifyKind(resident.BirthDay,DateTimeKind.Utc);
                
            try
            {
                await residentRepository.Add(newResident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao adicionar Residente ${resident.Id}");
            }
            return Ok($"Residente {resident.Id} criado!");
        }

        //PUT: v1/api/Resident/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateResident(
            [FromServices]IResidentRepository residentRepository,
            [FromServices]IUnitOfWork uow,
            int id, Resident resident)
        {
            if (id != resident.Id)
            {
                return NotFound($"Id {id} não é a mesma do Resident {resident.Name}");
            }
            Resident newResident = residenceService.CreateResident(resident);
            //Postgres exige utc explícito
            newResident.BirthDay = DateTime.SpecifyKind(newResident.BirthDay,DateTimeKind.Utc);
                
            try
            {
                await residentRepository.Update(newResident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao atualizar o Residente {resident.Id}");
            }
            return Ok($"Residente {resident.Id} atualizado!");
        }

        //DELETE: v1/api/Resident/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteResident(
            [FromServices]IResidentRepository residentRepository,
            [FromServices]IUnitOfWork uow,
            int id)
        {
            try
            {
                await residentRepository.Delete(id);
                uow.Commit();
            }
            catch
            {
                uow.RollBack();
                return UnprocessableEntity($"Erro ao deletar o Residente {id}");
            }
            return Ok($"Residente {id} deletado!");
        }

        //GET: v1/api/Resident/GetByApartment/1
        [HttpGet("GetByApartment/{id}")]
        public async Task<IEnumerable<Resident>> GetResidentByApartment(
            [FromServices]IResidentRepository residentRepository,
            int id)
        {
            var residents = residentRepository.GetByApartmentId(id);
            return residents;
        }


    }
}