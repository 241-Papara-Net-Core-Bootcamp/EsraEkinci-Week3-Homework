using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Repository.Domain.Entities;
using RepositoryPattern.Data.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace RepositoryPattern.Data.Concretes
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration _configuration;
        public DapperRepository(IConfiguration configuration)
        {
           _configuration = configuration;
        }
        /// <summary>
        /// ADD METHOD
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void AddAsync(Course entity)
        {
            var sql = "INSERT INTO Courses(CourseName,CourseType,CourseAdress,TrainerName,TrainerEmail,IsDeleted,CreatedDate,CreatedBy,LastModifiedDate) VALUES (@CourseName, @CourseType, @CourseAdress,@TrainerName,@TrainerEmail,@IsDeleted,@CreatedDate,@CreatedBy,@LastModifiedDate)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                
            }
        }

        /// <summary>
        /// DELETE METHOD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DeleteAsync(int CourseId)
        {
            var sql = "DELETE FROM Courses WHERE CourseId = @CourseId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(sql, new { CourseId = CourseId });
                
            }
        }

        /// <summary>
        /// GETALL METHOD.
        /// </summary>
        /// <returns></returns>
        public List<Course> GetAllAsync()
        {
            var sql = "SELECT * FROM Courses";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Query<Course>(sql);
                return result.ToList();

            }
        }

        /// <summary>
        /// GETBYID METHOD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Course> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Courses WHERE CourseId=@CourseId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var resultId = connection.QueryFirstOrDefault<Course>(sql , new {CourseId=id});
                return resultId;

            }
        }

        /// <summary>
        /// UPDATE METHOD
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(Course course)
        {
            var sql = "UPDATE Courses SET CourseName=@CourseName,CourseType=@CourseType,CourseAdress=@CourseAdress,TrainerName=@TrainerName,TrainerEmail=@TrainerEmail WHERE CourseId=@CourseId";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Execute(sql, course);
            }
        }

       
    }
}
