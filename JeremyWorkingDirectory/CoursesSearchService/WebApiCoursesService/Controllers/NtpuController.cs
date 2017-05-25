using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class NtpuController : ApiController
    {

        // GET: api/SuccesssCourses
        public IEnumerable<NtpuCoursesModel> GetAll()
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = from c in collection.AsQueryable<NtpuCoursesModel>()
                    select c;

            return q.Take(500);
        }

        public IEnumerable<NtpuCoursesModel> GetBySearchAll(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = from c in collection.AsQueryable<NtpuCoursesModel>()
                    where c.科目名稱.Contains(query) || c.授課教師.Contains(query) || c.開課系所.Contains(query) || c.備註.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<NtpuCoursesModel> GetByCourseName(string coursename)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = from c in collection.AsQueryable<NtpuCoursesModel>()
                    where c.科目名稱.Contains(coursename)
                    select c;

            return q;
        }


        public IEnumerable<NtpuCoursesModel> GetByTeacherName(string teachername)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = from c in collection.AsQueryable<NtpuCoursesModel>()
                    where c.科目名稱.Contains(teachername)
                    select c;

            return q;
        }

        public IEnumerable<NtpuCoursesModel> GetByDepartment(string department)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = from c in collection.AsQueryable<NtpuCoursesModel>()
                    where c.應修系級.Contains(department) || c.開課系所.Contains(department)
                    select c;

            return q;
        }

        public IEnumerable<NtpuCoursesModel> GetByWeekday(string weekday)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtpuCoursesModel>("ntpu");

            var q = from c in collection.AsQueryable<NtpuCoursesModel>()
                    where c.上課時間教室.Contains(weekday)
                    select c;

            return q;
        }

        // POST: api/Ntpu
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Ntpu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ntpu/5
        public void Delete(int id)
        {
        }
    }
}
