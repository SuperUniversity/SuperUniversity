using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CoursesSearchService
{
    [DataContract]
    public class DtoSuccess
    {
        [DataMember(Name = "課程名稱", Order = 1)]
        public string 課程名稱 { get; set; }
        [DataMember(Name = "年級", Order = 2)]
        public string 年級 { get; set; }
        [DataMember(Name = "班別", Order = 3)]
        public string 班別 { get; set; }
        [DataMember(Name = "組別", Order = 4)]
        public string 組別 { get; set; }

        [DataMember(Name = "已選課人數", Order = 5)]
        public string 已選課人數 { get; set; }
        [DataMember(Name = "餘額", Order = 6)]
        public string 餘額 { get; set; }

        [DataMember(Name = "教師姓名", Order = 7)]
        public string 教師姓名 { get; set; }
        [DataMember(Name = "時間", Order = 8)]
        public string 時間 { get; set; }
        [DataMember(Name = "教室", Order = 9)]
        public string 教室 { get; set; }


        [DataMember(Name = "學分", Order = 10)]
        public string 學分 { get; set; }
        [DataMember(Name = "選必修", Order = 11)]
        public string 選必修 { get; set; }

        [DataMember(Name = "系所名稱", Order = 12)]
        public string 系所名稱 { get; set; }

        [DataMember(Name = "限選條件", Order = 13)]
        public string 限選條件 { get; set; }

        [DataMember(Name = "英語授課", Order = 14)]
        public string 英語授課 { get; set; }

        [DataMember(Name = "跨領域學分學程", Order = 15)]
        public string 跨領域學分學程 { get; set; }

        [DataMember(Name = "Moocs", Order = 16)]
        public string Moocs { get; set; }

        [DataMember(Name = "業界專家參與", Order = 17)]
        public string 業界專家參與 { get; set; }

        [DataMember(Name = "備註", Order = 18)]
        public string 備註 { get; set; }



        public ObjectId _id { get; set; }
        public string 類別 { get; set; }
        public string 序號 { get; set; }
        public string 系號 { get; set; }
        public string 課程碼 { get; set; }
        public string 分班碼 { get; set; }
        public string 屬性碼 { get; set; }

        //        "_id" : ObjectId("5923bfcf99eff62ecc48fa68"),
        //"業界專家參與" : "否",
        //"英語授課" : "Y",
        //"年級" : null,
        ////////"類別" : "講義",
        //"時間" : "[5]9~A",
        ////////"序號" : "003",
        //"已選課人數" : "11",
        //"選必修" : "必修",
        //"系所名稱" : "臨醫所 CM",
        //"Moocs" : "否",
        //"教師姓名" : "張孔昭 顏家瑞 蔡坤哲 蘇文彬*",
        ////////"系號" : "S9",
        //"班別" : "博一",
        //"教室" : "門診大樓 7027",
        //"跨領域學分學程" : null,
        //"課程名稱" : "專題討論（二）",
        ////////"課程碼" : "S970320",
        //"餘額" : "53",
        ////////"分班碼" : null,
        //"備註" : "全英文",
        //"學分" : "1",
        //"組別" : null,
        ////////"屬性碼" : "CM7194",
        //"限選條件" : null

    }
}