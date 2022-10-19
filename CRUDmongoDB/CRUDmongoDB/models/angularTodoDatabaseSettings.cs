using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDmongoDB.Models
{
    public class AngularTodoDatabaseSettings : IAngularTodoDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string TodosCollectionName { get; set; } = null!;


    }
    public interface IAngularTodoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string TodosCollectionName { get; set; }


    }
}
