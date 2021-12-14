using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CondoManager.Models;
using CondoManager.Models.DTO;

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
                return NotFound();
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
                return NotFound();
            }
            return NoContent();
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
                return BadRequest();
            }
    
            try
            {
                await apartmentRepository.Update(apartment);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
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
                return NotFound();
            }
            return NoContent();
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
                return NotFound();
            }
            try
            {
                await apartmentRepository.AddResident(fromBody.IdApartment,resident);
                uow.Commit();
            } 
            catch 
            {
                uow.RollBack();
                return NotFound();
            }
            return NoContent();
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
                return NotFound();
            }
            try
            {
                await apartmentRepository.RemoveResident(fromBody.IdApartment,resident);
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