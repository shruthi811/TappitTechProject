using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TappitTechnicalTest.BusinessEntities;

namespace TappitTechnicalTest.BusinessServices
{
    public interface ISports
    {

        public IEnumerable<SportsEntity> GetListOfSports();
    }
}
