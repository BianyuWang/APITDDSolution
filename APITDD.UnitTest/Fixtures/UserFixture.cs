using APITDDSolution.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITDD.UnitTest.Fixtures
{
    public static class UserFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
            new User()
            {
             Id= 1,
           FirstName="Lea",
           LastName ="Li",
           Address = new Address()
           {
               CiviLNum = 1234,
               City="North Pole",
           PostalCode="h0h0h0",
           }
           },
              new User()
            {
             Id= 2,
           FirstName="Sdjaf",
           LastName ="Dsf",
           Address = new Address()
           {
               CiviLNum = 254,
               City="North Pole",
           PostalCode="h0h0h0",
           }
           },
                new User()
            {
             Id= 3,
           FirstName="Esfsdag",
           LastName ="Gse",
           Address = new Address()
           {
               CiviLNum = 789,
               City="North Pole",
           PostalCode="h0h0h0",
           }
           },

           };
           
            
            
            
            
    }
}
