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
    public class NtuController : ApiController
    {
        // GET api/values
        public IEnumerable<NtuCourseModel> GetAll()
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = from c in collection.AsQueryable<NtuCourseModel>()
                    select c;

            return q.Take(500);
            //return q;
        }

        // GET api/values/5
        public IEnumerable<NtuCourseModel> GetBySearchAll(string query)
        {
            //課程名稱，授課教師，授課對象，備註，選課限制條件
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = from c in collection.AsQueryable<NtuCourseModel>()
                    where c.課程名稱.Contains(query) || c.授課教師.Contains(query) || c.授課對象.Contains(query) || c.備註.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<NtuCourseModel> GetByCourseName(string coursename)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = from c in collection.AsQueryable<NtuCourseModel>()
                    where c.課程名稱.Contains(coursename)
                    select c;

            return q;
        }

        public IEnumerable<NtuCourseModel> GetByTeacherName(string teachername)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = from c in collection.AsQueryable<NtuCourseModel>()
                    where c.授課教師.Contains(teachername)
                    select c;

            return q;
        }

        public IEnumerable<NtuCourseModel> GetByDepartment(string department)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = from c in collection.AsQueryable<NtuCourseModel>()
                    where c.授課對象.Contains(department)
                    select c;

            return q;
        }

        public IEnumerable<NtuCourseModel> GetByWeekday(string weekday)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NtuCourseModel>("ntu");

            var q = from c in collection.AsQueryable<NtuCourseModel>()
                    where c.時間教室.Contains(weekday)
                    select c;

            return q;
        }


        // POST api/values
        public void Post([FromBody]string value)
        {



        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
