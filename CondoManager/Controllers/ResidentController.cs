using Microsoft.AspNetCore.Mvc;
using CondoManager.Models;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ResidentController : ControllerBase
    {
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
                return NotFound();
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
            //Postgres exige utc explícito
            resident.BirthDay = DateTime.SpecifyKind(resident.BirthDay,DateTimeKind.Utc);
                
            try
            {
                await residentRepository.Add(resident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
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
                return BadRequest();
            }

            //Postgres exige utc explícito
            resident.BirthDay = DateTime.SpecifyKind(resident.BirthDay,DateTimeKind.Utc);
                
            try
            {
                await residentRepository.Update(resident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
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
                return NotFound();
            }
            return NoContent();
        }


    }
}