using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCoursesService.Models
{
    public class MyBsonSerializer : IBsonSerializer
    {
        //public Type ValueType => throw new NotImplementedException();
        public Type ValueType { get; } = typeof(string);

        public object Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            while (context.Reader.State != BsonReaderState.Type || context.Reader.ReadBsonType() != BsonType.EndOfDocument)

            if (context.Reader.CurrentBsonType == BsonType.Int32)
            {
                return context.Reader.ReadInt32().ToString();
            }

            if (context.Reader.CurrentBsonType == BsonType.String)
            {
                return context.Reader.ReadString();
            }

            return null;
            
        }

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            context.Writer.WriteString(value as string);
        }

        //private static object GetNumberValue(BsonDeserializationContext context)
        //{
        //    var value = context.Reader.ReadInt32();

        //    switch (value)
        //    {
        //        case 1:
        //            return "one";
        //        case 2:
        //            return "two";
        //        case 3:
        //            return "three";
        //        default:
        //            return "BadType";
        //    }
        //}
    }
}