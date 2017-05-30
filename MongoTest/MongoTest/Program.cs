using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BsonClassMap.RegisterClassMap<Poco>();

            var client = new MongoClient();
            var database = client.GetDatabase("test");

            var collection = database.GetCollection<Poco>("cars");
            var queryable = collection.AsQueryable<Poco>();

            var count = queryable.Count();
            Console.WriteLine("Queryable {0} count: {1}", queryable, count);

            // Working example
            var cars = queryable.Select(a => a.Cars);

            foreach (IList<Car> car in cars)
            {
                Console.WriteLine("car.Count {0}", car.Count);
            }

            // Working example
            var qry = queryable.Select(a => a.Cars.Select(b => b.Engine));

            foreach (IList<Engine> engines in qry)
                foreach (Engine engine in engines)
                {
                    Console.WriteLine("Engine Type {0}, Displacement {1}", engine.Type, engine.Displacement);
                }

            // Working example
            var result = from a in queryable
                         from b in a.Cars
                         select b.Engine;

            foreach (Engine engine in result)
            {
                Console.WriteLine("Engine Type {0}, Displacement {1}", engine.Type, engine.Displacement);
            }

            // Working example
            // Note: it's not clear why I have to use List here instead of IList as above
            var drivers = queryable.Select(a => a.Cars.Select(b => b.Drivers));

            foreach (List<List<Driver>> listA in drivers)
                foreach (List<Driver> listB in listA)
                    foreach (Driver driver in listB)
                    {
                        Console.WriteLine("Driver Name: {0}, {1}", driver.Name.First, driver.Name.Last);
                    }

            // 'System.NotSupportedException' : {"$project or $group does not support {document}."}
            //var resultDriver = from a in queryable
            //             from b in a.Cars
            //             from c in b.Drivers
            //             select c;
            //foreach (Driver driver in resultDriver)
            //{
            //    Console.WriteLine("Driver Name: {0}, {1}", driver.Name.First, driver.Name.Last);
            //}

            // Working example
            // Note: it's not clear why I have to use IEnumerable here instead of List as above
            var cargoList = queryable.Select(a => a.Cars.Select(b => b.Trips.Select(c => c.Cargo)));

            foreach (List<IEnumerable<List<Cargo>>> listA in cargoList)
                foreach (IEnumerable<List<Cargo>> listB in listA)
                    foreach (List<Cargo> listC in listB)
                        foreach (Cargo cargo in listC)
                        {
                            Console.WriteLine("Cargo Name: {0}, Height: {1}", cargo.Info.Name, cargo.Size.Height);
                        }

            Console.ReadLine();
        }
    }
}
