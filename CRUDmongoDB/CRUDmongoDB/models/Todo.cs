using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDmongoDB.models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime endDate { get; set; } = new DateTime();
        public bool isCompleted { get; set; } = false;
        public bool isArchived { get; set; } = false;
        public bool isSelected { get; set; } = false;
        public int priority { get; set; } = 1;


    }
}
