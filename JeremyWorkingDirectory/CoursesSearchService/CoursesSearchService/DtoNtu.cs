using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CoursesSearchService
{
    [DataContract]
    public class DtoNtu
    {
        [DataMember(Name = "課程名稱", Order = 1)]
        public string 課程名稱 { get; set; }
        [DataMember(Name = "班次", Order = 2)]
        public string 班次 { get; set; }
        [DataMember(Name = "授課教師", Order = 3)]
        public string 授課教師 { get; set; }
        [DataMember(Name = "時間教室", Order = 4)]
        public string 時間教室 { get; set; }
        [DataMember(Name = "全半年", Order = 5)]
        public string 全半年 { get; set; }
        [DataMember(Name = "學分", Order = 6)]
        public string 學分 { get; set; }
        [DataMember(Name = "必選修", Order = 7)]
        public string 必選修 { get; set; }
        [DataMember(Name = "總人數", Order = 8)]
        public string 總人數 { get; set; }
        [DataMember(Name = "授課對象", Order = 9)]
        public string 授課對象 { get; set; }
        [DataMember(Name = "選課限制條件", Order = 10)]
        public string 選課限制條件 { get; set; }
        [DataMember(Name = "課程網頁", Order = 11)]
        public string 課程網頁 { get; set; }
        [DataMember(Name = "備註", Order = 12)]
        public string 備註 { get; set; }




        public ObjectId _id { get; set; }
        public string 本學期我預計要選的課程 { get; set; }
        public string 課號 { get; set; }
        public string 流水號 { get; set; }
        public string 加選方式 { get; set; }
        public string 課程識別碼 { get; set; }

        
    }
}