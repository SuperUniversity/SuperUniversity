using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApiCoursesService.Models;

namespace WebApiCoursesService.Controllers
{
    public class NckuController : ApiController
    {
        // GET: api/SuccesssCourses
        public async IEnumerable<NckuCourseModel> GetAll()
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");

            var q = from c in collection.AsQueryable<NckuCourseModel>()
                    select c;

            return q.Take(500);
        }

        public IEnumerable<NckuCourseModel> GetBySearchAll(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");

            var q = from c in collection.AsQueryable<NckuCourseModel>()
                    where c.課程名稱.Contains(query) || c.教師姓名.Contains(query) || c.系所名稱.Contains(query) || c.備註.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<NckuCourseModel> GetByCourseName(string coursename)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");

            var q = from c in collection.AsQueryable<NckuCourseModel>()
                    where c.課程名稱.Contains(coursename)
                    select c;

            return q;
        }


        public IEnumerable<NckuCourseModel> GetByTeacherName(string teachername)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");

            var q = from c in collection.AsQueryable<NckuCourseModel>()
                     where c.教師姓名.Contains(teachername)
                     select c;

            return q;
        }

        public IEnumerable<NckuCourseModel> GetByDepartment(string department)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");


            var q = from c in collection.AsQueryable<NckuCourseModel>()
                    where c.系所名稱.Contains(department)
                    select c;

            return q;
        }


        // GET: api/SuccesssCourses/5
        public IEnumerable<NckuCourseModel> GetByWeekday(string Weekday)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");


            var q = (from c in collection.AsQueryable<NckuCourseModel>()
                    select c).Where(c => c.時間.Contains(Weekday));

            return q;
        }

        public IEnumerable<NckuCourseModel> GetByID(string strid)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");

            ObjectId Objid = new ObjectId(strid);
            var q = (from c in collection.AsQueryable<NckuCourseModel>()
                     select c).Where(c => c._id == Objid);

            return q;
        }


        // POST: api/SuccesssCourses(insert)
        public async void Post([FromBody]NckuCourseModel ocoursedata)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");
            await collection.InsertOneAsync(ocoursedata);
        }

        ////// PUT: api/Ncku/5(Update)
        //public async void PutComment(string strid, string comment, string name)
        //{
        //    //id 前面加上[FromBody]，表示要從 HTTP POST 內文來取得參數值：
        //    var _client = new MongoClient();
        //    var _database = _client.GetDatabase("SuperUniversityCourses");
        //    var collection = _database.GetCollection<NckuCourseModel>("ncku");

        //    ObjectId Objid = new ObjectId(strid);
        //    var filter = Builders<NckuCourseModel>.Filter.Eq("_id", Objid);
        //    var cursor = collection.Find(filter);
        //    List<NckuCourseModel.comment> OgigianlComments = cursor.FirstOrDefault().commentdata;
        //    NckuCourseModel.comment InputComment = new NckuCourseModel.comment() { commentstring = comment, name = name };


        //    UpdateDefinition<NckuCourseModel> update;
        //    if (OgigianlComments == null)
        //    {
        //        List<NckuCourseModel.comment> InputCommentData = new List<NckuCourseModel.comment>();
        //        InputCommentData.Add(InputComment);
        //        update = Builders<NckuCourseModel>.Update
        //                    .Set("commentdata", InputCommentData)
        //                    .CurrentDate("lastModified");
        //    }
        //    else
        //    {
        //        OgigianlComments.Add(InputComment);
        //        update = Builders<NckuCourseModel>.Update
        //                    .Set("commentdata", OgigianlComments)
        //                    .CurrentDate("lastModified");
        //    }

        //    var result = await collection.UpdateOneAsync(filter, update);
        //}



        //// PUT: api/Ncku/5(Update)
        public async void PutComment(string strid, [FromBody]NckuCourseModel.comment comment)
        {
            //id 前面加上[FromBody]，表示要從 HTTP POST 內文來取得參數值：
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");

            ObjectId Objid = new ObjectId(strid);
            var filter = Builders<NckuCourseModel>.Filter.Eq("_id", Objid);
            var cursor = collection.Find(filter);
            List<NckuCourseModel.comment> OrigianlComments = cursor.FirstOrDefault().commentdata;
            NckuCourseModel.comment InputComment = comment;


            UpdateDefinition<NckuCourseModel> update;
            if (OrigianlComments == null)
            {
                List<NckuCourseModel.comment> InputCommentData = new List<NckuCourseModel.comment>();
                InputCommentData.Add(InputComment);
                update = Builders<NckuCourseModel>.Update
                            .Set("commentdata", InputCommentData)
                            .CurrentDate("lastModified");
            }
            else
            {
                OrigianlComments.Add(InputComment);
                update = Builders<NckuCourseModel>.Update
                            .Set("commentdata", OrigianlComments)
                            .CurrentDate("lastModified");
            }

            var result = await collection.UpdateOneAsync(filter, update);
        }

        //public async void PutComment(string strid, NckuCourseModel entity)
        //{
        //    //id 前面加上[FromBody]，表示要從 HTTP POST 內文來取得參數值：
        //    var _client = new MongoClient();
        //    var _database = _client.GetDatabase("SuperUniversityCourses");
        //    var collection = _database.GetCollection<NckuCourseModel>("ncku");


        //    UpdateDefinition<NckuCourseModel> update = Builders<NckuCourseModel>.Update
        //                .Set("commentdata", entity.commentdata)
        //                .CurrentDate("lastModified");

        //    var filter = Builders<NckuCourseModel>.Filter.Eq("_id", strid);
        //    var result = await collection.UpdateOneAsync(filter, update);
        //}

        //public async void PutComment(NckuCourseModel entity)
        //{
        //    //id 前面加上[FromBody]，表示要從 HTTP POST 內文來取得參數值：
        //    var _client = new MongoClient();
        //    var _database = _client.GetDatabase("SuperUniversityCourses");
        //    var collection = _database.GetCollection<NckuCourseModel>("ncku");

        //    var filter = Builders<NckuCourseModel>.Filter.Eq("_id", entity._id);

        //    UpdateDefinition<NckuCourseModel> update = Builders<NckuCourseModel>.Update
        //                .Set("commentdata", entity.commentdata)
        //                .CurrentDate("lastModified");

        //    var result = await collection.UpdateOneAsync(filter, update);
        //}

        //public async void PutComment()
        //{
        //    //id 前面加上[FromBody]，表示要從 HTTP POST 內文來取得參數值：
        //    var _client = new MongoClient();
        //    var _database = _client.GetDatabase("SuperUniversityCourses");
        //    var collection = _database.GetCollection<NckuCourseModel>("ncku");

        //    ObjectId Objid = new ObjectId("5925025299eff624342895d5");
        //    var filter = Builders<NckuCourseModel>.Filter.Eq("_id", Objid);
        //    var cursor = collection.Find(filter);
        //    List<string> comments = cursor.FirstOrDefault().comment;


        //    UpdateDefinition<NckuCourseModel> update;
        //    if (comments == null)
        //    {
        //        List<string> InputComments = new List<string>();
        //        InputComments.Add("Good");
        //        update = Builders<NckuCourseModel>.Update
        //                    .Set("comment", InputComments)
        //                    .CurrentDate("lastModified");
        //    }
        //    else
        //    {
        //        comments.Add("Good");
        //        update = Builders<NckuCourseModel>.Update
        //                    .Set("comment", comments)
        //                    .CurrentDate("lastModified");
        //    }

        //    var result = await collection.UpdateOneAsync(filter, update);
        //}

        // DELETE: api/Ncku/5
        public async void Delete(string strid)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<NckuCourseModel>("ncku");

            ObjectId Objid = new ObjectId(strid);
            var filter = Builders<NckuCourseModel>.Filter.Eq("_id", Objid);

            var result = await collection.DeleteOneAsync(filter);

        }
    }
}
