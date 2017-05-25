using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Threading;

namespace CoursesSearchService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service1"。
    // 注意: 若要啟動 WCF 測試用戶端以便測試此服務，請在 [方案總管] 中選取 Service1.svc 或 Service1.svc.cs，然後開始偵錯。
    public class Service1 : IService1
    {

        public IEnumerable<DtoNtu> GetNtuCourses()
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoNtu>("ntu");

            var q = from c in collection.AsQueryable<DtoNtu>()
                    select c;

            return q.Take(100);
        }

        public IEnumerable<DtoNtu> GetNtuCoursesBySearchAll(string query)
        {
            //課程名稱，授課教師，授課對象，備註，選課限制條件
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoNtu>("ntu");

            var q = from c in collection.AsQueryable<DtoNtu>()
                    where c.課程名稱.Contains(query) || c.授課教師.Contains(query) || c.選課限制條件.Contains(query) ||
                    c.授課對象.Contains(query) || c.備註.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<DtoNtu> GetNtuCoursesByCourseName(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoNtu>("ntu");

            var q = from c in collection.AsQueryable<DtoNtu>()
                    where c.時間教室.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<DtoNtu> GetNtuCoursesByTeacher(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoNtu>("ntu");

            var q = from c in collection.AsQueryable<DtoNtu>()
                    where c.授課教師.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<DtoNtu> GetNtuCoursesBySearchDepartment(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoNtu>("ntu");

            var q = from c in collection.AsQueryable<DtoNtu>()
                    where c.授課對象.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<DtoNtu> GetNtuCoursesByWeekday(string Weekday)
        {
            //Weekday = chinese 一~五
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoNtu>("ntu");

            var q = from c in collection.AsQueryable<DtoNtu>()
                    where c.時間教室.Contains(Weekday)
                    select c;

            return q.Take(100);
        }

        public IEnumerable<DtoSuccess> GetSuccessCourses()
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoSuccess>("success");

            var q = from c in collection.AsQueryable<DtoSuccess>()
                    select c;

            return q.Take(50);
        }

        public IEnumerable<DtoSuccess> GetSuccessCoursesBySearchAll(string query)
        {
            //課程名稱，教師姓名，系所名稱，備註，限選條件
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoSuccess>("success");

            var q = from c in collection.AsQueryable<DtoSuccess>()
                    where c.系所名稱.Contains(query)|| c.課程名稱.Contains(query) ||
                    c.限選條件.Contains(query) || c.教師姓名.Contains(query) || c.備註.Contains(query) 
                    select c;

            return q.Take(50);
        }

        public IEnumerable<DtoSuccess> GetSuccessCoursesByCourseName(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoSuccess>("success");

            var q = from c in collection.AsQueryable<DtoSuccess>()
                    where c.課程名稱.Contains(query) 
                    select c;

            return q;
        }

        public IEnumerable<DtoSuccess> GetSuccessCoursesByTeacher(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoSuccess>("success");

            var q = from c in collection.AsQueryable<DtoSuccess>()
                    where c.教師姓名.Contains(query)
                    select c;

            return q;
        }

        public IEnumerable<DtoSuccess> GetSuccessCoursesByWeekday(string Weekday)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoSuccess>("success");


            var q = (from c in collection.AsQueryable<DtoSuccess>()
                     select c).Where(c => c.時間.Contains(Weekday));

            return q.Take(50);
        }

        public IEnumerable<DtoSuccess> GetSuccessCoursesBySearchDepartment(string query)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("SuperUniversityCourses");
            var collection = _database.GetCollection<DtoSuccess>("success");

            var q = from c in collection.AsQueryable<DtoSuccess>()
                    where c.系所名稱.Contains(query)
                    select c;

            return q;
        }
    }
}
