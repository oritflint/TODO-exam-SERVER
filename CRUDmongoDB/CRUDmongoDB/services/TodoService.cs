using CRUDmongoDB.models;
using CRUDmongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDmongoDB.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todos;

        public TodoService(IAngularTodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _todos = database.GetCollection<Todo>(settings.TodosCollectionName);
        }

        public List<Todo> Get() =>
            _todos.Find(todo => true).ToList();

        public Todo Get(string id) =>
            _todos.Find<Todo>(todo => todo.Id == id).FirstOrDefault();

        public async Task CreateAsync(Todo todo)
        {
            await _todos.InsertOneAsync(todo);
            return;
        }

        public void Update(string id, Todo todoIn) =>
            _todos.ReplaceOne(todo => todo.Id == id, todoIn);

        public void Remove(Todo todoIn) =>
            _todos.DeleteOne(todo => todo.Id == todoIn.Id);

        public void Remove(string id) =>
            _todos.DeleteOne(todo => todo.Id == id);
    }
}