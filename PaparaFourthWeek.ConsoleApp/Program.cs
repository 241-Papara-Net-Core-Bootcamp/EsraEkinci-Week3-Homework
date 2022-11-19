using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PaparaFourthWeek.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDbConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB ; DataBase=RepositoryPatternDb; Trusted_Connection=True;");
            con.Open();
            con.Execute(@"INSERT INTO [dbo].[Courses]
            ([CourseName]
            ,[CourseType]
            ,[CourseAdress]
            ,[TrainerName]
            ,[TrainerEmail]
            ,[IsDeleted]
            ,[CreatedDate]
            ,[CreatedBy]
            ,[LastModifiedDate])
            VALUES(@CourseName,
            @CourseType,
            @CourseAdress,
            @TrainerName,
            @TrainerEmail,
            @IsDeleted,
            @CreatedDate,
            @CreatedBy,
            @LastModifiedDate)",new Course
            {
                CourseName="Music",
                CourseType="Art",
                CourseAdress="Kemer",
                TrainerName="Jacob",
                TrainerEmail="jacob@bla.com",
                IsDeleted=false,
                CreatedDate=DateTime.Now,
                CreatedBy="Admin"
            });
            var courseList = con.Query<Course>("select * from Courses").ToList();

            foreach (var course in courseList)
            {
                Console.WriteLine(course.CourseName);   
            }
            con.Close();
        }
    }
}
