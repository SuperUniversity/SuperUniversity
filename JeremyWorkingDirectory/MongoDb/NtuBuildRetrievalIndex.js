db.getCollection('ntu1').createIndex(
  {  
    學分 : "text",
    時間教室 : "text",
    備註 : "text",
    總人數 : "text",
    選課限制條件 : "text"
  }
)



exclude
    必選修 : "text",
    全半年 : "text",
    授課教師 : "text",
    授課對象 : "text",
    課程名稱 : "text",