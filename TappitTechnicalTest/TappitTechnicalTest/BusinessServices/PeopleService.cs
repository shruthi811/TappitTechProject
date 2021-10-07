using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TappitTechnicalTest.BusinessEntities;
using TappitTechnicalTest.Models;

namespace TappitTechnicalTest.BusinessServices
{
    public class PeopleService : IPeople
    {
        private readonly tappit_dbContext _db;
        public PeopleService()
        {
            _db = new tappit_dbContext();
        }

        public IEnumerable<PeopleFavoriteSportEntity> GetAllPeople()
        {
            var people = _db
                .People.Include(person => person.FavouriteSports)
                .ThenInclude(favouriteSport => favouriteSport.Sport)
                .ToList();
             var list=people.Select(person => new PeopleFavoriteSportEntity
             {
                 FirstName = person.FirstName,
                 LastName = person.LastName,
                 PersonId = person.PersonId,
                 IsEnabled = person.IsEnabled,
                 IsAuthorised = person.IsAuthorised,
                 IsValid = person.IsValid,
                 IsPalindrom = IsPalindrome(person.FirstName),
                 FavouriteSports = person.FavouriteSports.Select(sport => sport.Sport.Name)
             });

            return list;
        }
        public static bool IsPalindrome(string name)
        {
            string string1, rev;
            string1 = name;
            char[] ch = string1.ToCharArray();
            Array.Reverse(ch);
            rev = new string(ch);
            return  string1.Equals(rev, StringComparison.OrdinalIgnoreCase);           
        }
       
        public PeopleEntity GetById(int id)
        {
            var sportsList = _db.Sports.Include(sport => sport.FavouriteSports).ToList();
              
            var person = _db.People.Include(person => person.FavouriteSports)
                .ThenInclude(favouriteSport => favouriteSport.Sport)
                .FirstOrDefault(person => person.PersonId == id);
            if (person != null)
            {
                return new PeopleEntity
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    PersonId = person.PersonId,
                    IsEnabled = person.IsEnabled,
                    IsAuthorised = person.IsAuthorised,
                    IsValid = person.IsValid,
                    FavouriteSports = sportsList.Select(sport => sport.Name)
                };
            }
            else
                return null;
        }

        public Person UpdateRecord(int PersonID, PersonDataEntity personDetail)
        {

            Person personData = _db.People.Where(temp => temp.PersonId == PersonID).FirstOrDefault();
            if (personData != null)
            {
                personData.FirstName = personDetail.FirstName;
                personData.LastName = personDetail.LastName;
                personData.IsEnabled = personDetail.IsEnabled;
                personData.IsAuthorised = personDetail.IsAuthorised;
                personData.IsValid = personDetail.IsValid;
                _db.SaveChanges();            

            }
            return personData;
        }
    }
}
