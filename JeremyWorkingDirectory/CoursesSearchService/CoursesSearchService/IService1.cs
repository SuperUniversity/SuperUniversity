using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSearchService
{
    // 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼和組態檔中的介面名稱 "IService1"。
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        IEnumerable<DtoNtu> GetNtuCourses();

        [OperationContract]
        IEnumerable<DtoNtu> GetNtuCoursesBySearchAll(string query);

        [OperationContract]
        IEnumerable<DtoNtu> GetNtuCoursesByCourseName(string query);

        [OperationContract]
        IEnumerable<DtoNtu> GetNtuCoursesByTeacher(string query);

        [OperationContract]
        IEnumerable<DtoNtu> GetNtuCoursesByWeekday(string Weekday);

        [OperationContract]
        IEnumerable<DtoNtu> GetNtuCoursesBySearchDepartment(string query);




        [OperationContract]
        IEnumerable<DtoSuccess> GetSuccessCourses();

        [OperationContract]
        IEnumerable<DtoSuccess> GetSuccessCoursesBySearchAll(string query);

        [OperationContract]
        IEnumerable<DtoSuccess> GetSuccessCoursesByCourseName(string query);

        [OperationContract]
        IEnumerable<DtoSuccess> GetSuccessCoursesByTeacher(string query);

        [OperationContract]
        IEnumerable<DtoSuccess> GetSuccessCoursesByWeekday(string Weekday);

        [OperationContract]
        IEnumerable<DtoSuccess> GetSuccessCoursesBySearchDepartment(string query);
    }

}
