using AvcolStaff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvcolStaff.Data
{
    public class DbInitializer
    {
        public static void Initialize(AvcolStaffContext context)
        {
            context.Database.EnsureCreated();

            // Look for any staffs.
            if (context.Staff.Any())
            {
                return;   // DB has been seeded
            }

            var staffs = new Staff[]
            {
                new Staff{FirstName="Lindy",LastName="Watkinson",TeacherCode="LWA",HireDate=DateTime.Parse("2019-12-01")},
                new Staff{FirstName="Jamie",LastName="Smith",TeacherCode="JSM",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Grace",LastName="Williams",TeacherCode="GWI",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Yasmin",LastName="Khan",TeacherCode="YKH",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Emma",LastName="Watt",TeacherCode="EWA",HireDate=DateTime.Parse("2017-10-01")},
                new Staff{FirstName="Jaqui",LastName="Brikhead",TeacherCode="JBR",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Charlotte",LastName="Houghton",TeacherCode="CHO",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Andrew",LastName="Bramston",TeacherCode="ABR",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Santana ",LastName="Schmidt",TeacherCode="SSC",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Erica",LastName="Norton",TeacherCode="ENO",HireDate=DateTime.Parse("2014-09-01")},
                new Staff{FirstName="Selina",LastName="Tonkin",TeacherCode="STO",HireDate=DateTime.Parse("2067-09-01")},
                new Staff{FirstName="Sharon",LastName="Cope",TeacherCode="SCO",HireDate=DateTime.Parse("2014-09-09")},
                new Staff{FirstName="Pushpa",LastName="Dayal",TeacherCode="PDA",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Jin",LastName="Tai",TeacherCode="JTA",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Hannah",LastName="Normington",TeacherCode="HNO",HireDate=DateTime.Parse("2013-09-06")},
                new Staff{FirstName="Santana ",LastName="Schmidt",TeacherCode="SSC",HireDate=DateTime.Parse("2017-07-01")},//DUPLICATE TEACHER CODE!
                new Staff{FirstName="James",LastName="Went",TeacherCode="JWE",HireDate=DateTime.Parse("2067-09-01")},
                new Staff{FirstName="Chris",LastName="Klaassen",TeacherCode="CKL",HireDate=DateTime.Parse("2019-12-01")},
                new Staff{FirstName="Anthony",LastName="Munro",TeacherCode="AMU",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="James",LastName="Palmer",TeacherCode="JPA",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Jean",LastName="Mansill",TeacherCode="JMA",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Grant",LastName="Burden",TeacherCode="GBU",HireDate=DateTime.Parse("2017-10-01")},
                new Staff{FirstName="Elizabeth",LastName="Atkinson",TeacherCode="EAT",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Charlotte",LastName="Houghton",TeacherCode="CHO",HireDate=DateTime.Parse("2017-09-01")},//Duplicate Record
                new Staff{FirstName="Ngarama",LastName="Howell",TeacherCode="NHO",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Zameer",LastName="Mazid",TeacherCode="ZMA",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Julie",LastName="Garner",TeacherCode="JGA",HireDate=DateTime.Parse("2014-09-01")},
                new Staff{FirstName="Jonelle",LastName="Henry",TeacherCode="JHE",HireDate=DateTime.Parse("2014-09-09")},
                new Staff{FirstName="Brian",LastName="Quedley",TeacherCode="BQU",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="Philip",LastName="Irwin",TeacherCode="PIR",HireDate=DateTime.Parse("2017-09-01")},
                new Staff{FirstName="G",LastName="Hanna",TeacherCode="GHA",HireDate=DateTime.Parse("2013-09-06")},
                new Staff{FirstName="Jenifer",LastName="Brown",TeacherCode="JBO",HireDate=DateTime.Parse("2017-07-01")},
                new Staff{FirstName="Bevan",LastName="Jones",TeacherCode="BJO",HireDate=DateTime.Parse("2067-09-01")},
                new Staff{FirstName="Meg",LastName="Goldthrope",TeacherCode="MGO",HireDate=DateTime.Parse("2013-09-06")},
                new Staff{FirstName="Neil",LastName="Bartlett",TeacherCode="NBA",HireDate=DateTime.Parse("2017-07-01")},
                new Staff{FirstName="Shane",LastName="Laurence",TeacherCode="SLA",HireDate=DateTime.Parse("2067-09-01")}
            };

            context.Staff.AddRange(staffs);
            context.SaveChanges();
            /*

            var courses = new Course[]
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
            context.SaveChanges();*/
        }
    }
}
    


