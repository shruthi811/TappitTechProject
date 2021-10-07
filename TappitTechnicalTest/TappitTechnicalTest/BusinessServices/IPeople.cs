using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TappitTechnicalTest.BusinessEntities;
using TappitTechnicalTest.Models;

namespace TappitTechnicalTest.BusinessServices
{
    public  interface IPeople
    {
        IEnumerable<PeopleFavoriteSportEntity> GetAllPeople();
        PeopleEntity GetById(int id);
        Person UpdateRecord(int PersonID,PersonDataEntity personRecord);
    }
}
