using CRUDmongoDB.IRepository;
using CRUDmongoDB.models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CRUDmongoDB.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Todo> _todoTable = null;

        public TodoRepository()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            _database = _mongoClient.GetDatabase("OfficeDB");
            _todoTable = _database.GetCollection<Todo>("todos");
        }


        public string Delete(string TodoId)
        {
            _todoTable.DeleteOne(x => x.Id == TodoId);
            return "deleted";
        }

        public Todo Get(string TodoId)
        {
            return _todoTable.Find(x => x.Id == TodoId).FirstOrDefault();
        }

        public List<Todo> Gets()
        {
            return _todoTable.Find(FilterDefinition<Todo>.Empty).ToList();
        }

        public Todo Save(Todo todo)
        {
            var TodoObj = _todoTable.Find(x => x.Id == todo.Id).FirstOrDefault();
            if (TodoObj == null)
                _todoTable.InsertOne(todo);
            else
                _todoTable.ReplaceOne(x => x.Id == todo.Id, todo);

            return todo;

        }
    }
}
