using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TappitTechnicalTest.BusinessEntities;
using TappitTechnicalTest.BusinessServices;



namespace TappitTechnicalTest.Controllers
{
    
    [ApiController]
    public class SportsController : ControllerBase
    {      
        private readonly ISports _sportService;

        public SportsController(ISports sportService)
        {
            _sportService = sportService;
        }
        
      
        [HttpGet]
        [Route("api/GetSportsList")]
        public IEnumerable<SportsEntity> GetSportsList()
        {
               return _sportService.GetListOfSports();
     
        }
    }
}
