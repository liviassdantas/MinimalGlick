using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace MinimalGlick.Models
{
    public class Glycemia
    {
        [BsonId]
        [BsonElement("Id")]
        [NotNull]
        public int Id { get; set; }

        [BsonElement("DateTimeRecord")]
        public DateTime DateTimeRecord { get; set; }

        [BsonElement("MeasureValue")]
        public Int16 MeasureValue { get; set; }


    }
}
