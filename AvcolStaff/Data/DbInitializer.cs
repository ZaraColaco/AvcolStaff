using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Data
{
    using AvcolStaff.Data;
    using AvcolStaff.Models;
    using System;
    using System.Linq;

    namespace ContosoUniversity.Data
    {
        public static class DbInitializer
        {
            public static void Initialize(AvcolStaffContext context)
            {
                context.Database.EnsureCreated();

                // Look for any staff.
                if (context.Staff.Any())
                {
                    return;   // DB has been seeded
                }

                var staffs = new Staff[]
                {
                new Staff{FirstName="Lindy",LastName="Watkinson",HireDate=DateTime.Parse("2019-12-01")},
                new Staff{FirstName="Jamie",LastName="Smith",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Grace",LastName="Williams",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Yasmin",LastName="Khan",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Emma",LastName="Watt",HireDate=DateTime.Parse("2017-10-01")},
                new Staff{FirstName="Jaqui",LastName="Brikhead",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Charlotte",LastName="Houghton",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Andrew",LastName="Bramston",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Santana ",LastName="Schmidt",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Erica",LastName="Norton",HireDate=DateTime.Parse("2014-09-01")},
                new Staff{FirstName="Selina",LastName="Tonkin",HireDate=DateTime.Parse("2067-09-01")},
                new Staff{FirstName="Sharon",LastName="Cope",HireDate=DateTime.Parse("2014-09-09")},
                new Staff{FirstName="Pushpa",LastName="Dayal",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Jin",LastName="Tai",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Hannah",LastName="Normington",HireDate=DateTime.Parse("2013-09-06")},
                new Staff{FirstName="Santana ",LastName="Schmidt",HireDate=DateTime.Parse("2017-07-01")},
                new Staff{FirstName="James",LastName="Went",HireDate=DateTime.Parse("2067-09-01")},
                new Staff{FirstName="Chris",LastName="Klaassen",HireDate=DateTime.Parse("2019-12-01")},
                new Staff{FirstName="Anthony",LastName="Munro",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="James",LastName="Palmer",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Jean",LastName="Mansill",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Grant",LastName="Burden",HireDate=DateTime.Parse("2017-10-01")},
                new Staff{FirstName="Elizabeth",LastName="Atkinson",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Charlotte",LastName="Houghton",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Ngarama",LastName="Howell",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Zameer",LastName="Mazid",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Julie",LastName="Garner",HireDate=DateTime.Parse("2014-09-01")},
                new Staff{FirstName="Jonelle",LastName="Henry",HireDate=DateTime.Parse("2014-09-09")},
                new Staff{FirstName="Brian",LastName="Quedley",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Philip",LastName="Irwin",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="G",LastName="Hanna",HireDate=DateTime.Parse("2013-09-06")},
                new Staff{FirstName="Jenifer",LastName="Brown",HireDate=DateTime.Parse("2017-07-01")},
                new Staff{FirstName="Bevan",LastName="Jones",HireDate=DateTime.Parse("2067-09-01")},
                new Staff{FirstName="Meg",LastName="Goldthrope",HireDate=DateTime.Parse("2013-09-06")},
                new Staff{FirstName="Neil",LastName="Bartlett",HireDate=DateTime.Parse("2017-07-01")},
                new Staff{FirstName="Shane",LastName="Laurence",HireDate=DateTime.Parse("2067-09-01")},





                };

                context.Staff.AddRange(staffs);
                context.SaveChanges();

                /* var courses = new Course[]
                 {
                 new Course{CourseID=1050,Title="Chemistry",Credits=3},
                 new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                 new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                 new Course{CourseID=1045,Title="Calculus",Credits=4},
                 new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                 new Course{CourseID=2021,Title="Composition",Credits=3},
                 new Course{CourseID=2042,Title="Literature",Credits=4}
                 };

                 context.Courses.AddRange(courses);
                 context.SaveChanges();

                 var enrollments = new Enrollment[]
                 {
                 new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                 new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                 new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                 new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                 new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                 new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                 new Enrollment{StudentID=3,CourseID=1050},
                 new Enrollment{StudentID=4,CourseID=1050},
                 new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                 new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
                 new Enrollment{StudentID=6,CourseID=1045},
                 new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
                 };

                 context.Enrollments.AddRange(enrollments);
                 context.SaveChanges();
             }*/
            }
        }
    }
}
