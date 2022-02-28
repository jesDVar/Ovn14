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

            if (await db.Course.AnyAsync()) return;

            faker = new Faker("sv");

            var courses = GetCourses();
            await db.AddRangeAsync(courses);

            await db.SaveChangesAsync();

            //DAVID
            //lägg ej i Idn
            //skapa moduler först
            //lägg in modulerna i Course.Modules
        }

        private static IEnumerable<Course> GetCourses()
        {
            var courses = new List<Course>();

            for (int i = 0; i < 20; i++)
            {
                var course = new Course();
                course.Title = faker.Company.CompanyName();
                course.StartDate = faker.Date.Future();
                course.Modules = new List<Module>
                {
                    new Module()
                    {Title = faker.Name.LastName(),
                    StartDate = faker.Date.Future()
                    },

                    new Module()
                    {Title = faker.Name.LastName(),
                    StartDate = faker.Date.Future()
                    }

                };        
              
                courses.Add(course);                                
            }
            return courses;            
        }
    }
}
