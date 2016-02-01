using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SFCrimeDatabaseService.Entities
{
    [BsonIgnoreExtraElements]
    public class TrainingCrime
    {
        [BsonRepresentation(BsonType.ObjectId), BsonId]
        public string Id { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Resolution { get; set; }

        public string Address { get; set; }

        public string PDDistrict { get; set; }

        public string DayOfWeek { get; set; }

        public DateTime Date { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
