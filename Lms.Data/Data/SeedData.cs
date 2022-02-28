using Bogus;
using Lms.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lms.Data.Data
{
    public class SeedData
    {
        private static Faker faker;

        public static async Task InitAsync(LmsApiContext db)
        {

            if (await db.Course.AnyAsync()) return;

            faker = new Faker("sv");

            var courses = GetCourses();
            await db.AddRangeAsync(courses);

            await db.SaveChangesAsync();
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
