using MongoDB.Bson.Serialization.Attributes;

namespace MinimalGlick.Models
{
    public class GlycemiaModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] 
        public int Id { get; set; }

        [BsonElement("DateTimeRecord")]
        public DateTime DateTimeRecord { get; set; }

        [BsonElement("MeasureValue")]
        public Int16 MeasureValue { get; set; }


    }
}
