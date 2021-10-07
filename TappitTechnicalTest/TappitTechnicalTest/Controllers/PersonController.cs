
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TappitTechnicalTest.BusinessEntities;
using TappitTechnicalTest.BusinessServices;
using TappitTechnicalTest.Models;

namespace TappitTechnicalTest.Controllers
{
   
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPeople _peopleService;
        public PersonController(IPeople people)
        {
            _peopleService = people;
        }
        [HttpGet]
        [Route("api/GetAllPersonsRecord")]
        public IEnumerable<PeopleFavoriteSportEntity> GetAll()
        {
            return _peopleService.GetAllPeople();
        }

        [HttpGet]
        [Route("api/GetPersonRecordByID")]    
        public IActionResult GetById(int personID)
        {
            var result = _peopleService.GetById(personID);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Person ID does not exists.");
            }
        }

        [HttpPut]
        [Route("api/UpdatePersonRecord")]
        public IActionResult UpdatePersonRecord(int PersonID, PersonDataEntity persondetail)
        {
           Person personRecord= _peopleService.UpdateRecord(PersonID,persondetail);
            if (personRecord != null)
                return Ok(personRecord);
            else
                return NotFound("Person ID does not exists.");
        }

    }
}
