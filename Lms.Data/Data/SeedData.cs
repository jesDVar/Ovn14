using Bogus;
using Lms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Data
{
    public class SeedData
    {
        private static Faker faker;

        //+++++++++++++++++++++++++++++++++
        //Lagt till db
        public static async Task InitAsync(LmsApiContext db)
        {
            //+++++++++++++++++++++++++++++
            //Lagt till if.../Ändrat från Module till Course, vet ej vilken det ska vara

            if (await db.Course.AnyAsync()) return;

            Faker faker = new Faker("sv");

            var courses = GetCourses(); 

            //DAVID
            //lägg ej i Idn
            //skapa moduler först
            //lägg in modulerna i Course.Modules
        }

        private static IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}
