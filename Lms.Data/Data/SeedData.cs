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

            Faker faker = new Faker("sv");

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

            for (int i = 0; i < 20; i++) ;
            {
                var titel = faker.Company.CompanyName();
                var startDate = faker.Date.Future();

                var course = new Course
                {
                    Title = titel,
                    StartDate = startDate,
                };

                courses.Add(course);
            }
            return courses;
        }
    }
}
