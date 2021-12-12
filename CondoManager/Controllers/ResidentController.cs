using Microsoft.AspNetCore.Mvc;
using CondoManager.Models;

namespace CondoManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResidentController : ControllerBase
    {
        [HttpPut(Name = "UpdateResident")]
        public async Task UpdateResident(
            [FromServices]ResidentRepository residentRepository,
            [FromServices]IUnitOfWork uow,
            Resident resident)
        {
            //
        }

        [HttpPost(Name = "CreateResident")]
        public async Task CreateResident(
            [FromServices]IResidentRepository residentRepository,
            [FromServices]IUnitOfWork uow,
            Resident resident)
        {
            try
            {
                //Postgres exige utc explícito
                resident.BirthDay = DateTime.SpecifyKind(resident.BirthDay,DateTimeKind.Utc);
                //todo validar dados
                await residentRepository.Add(resident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
            }
        }

    }
}