using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TappitTechnicalTest.BusinessEntities;
using TappitTechnicalTest.Models;

namespace TappitTechnicalTest.BusinessServices
{
    public class SportsService : ISports
    {   
        private readonly tappit_dbContext _db;
        public SportsService()
        {
            _db = new tappit_dbContext();
          
        }
        public IEnumerable<SportsEntity> GetListOfSports()
        {
            var sportsList = _db.Sports.Include(sport => sport.FavouriteSports).ToList();

            return sportsList.Select(sport => new SportsEntity
            {
                SportName = sport.Name,
                NoOfFavorites = sport.FavouriteSports.Count()
            });
        }
    }
}
