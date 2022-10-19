using CRUDmongoDB.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDmongoDB.IRepository
{
    public interface ITodoRepository
    {
        Todo Save(Todo todo);
        Todo Get(string TodoId);
        List<Todo> Gets();
        string Delete(string TodoId);

    }
}
