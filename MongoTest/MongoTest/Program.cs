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

            Console.WriteLine("");

            // Case A
            // Work as expected  
            var cars = queryable.SelectMany(a => a.Cars);

            foreach (Car car in cars)
            {
                Console.WriteLine("Car Engine Type {0}, Displacement {1}", car.Engine.Type, car.Engine.Displacement);
            }

            Console.WriteLine("");

            // Case B1
            // Work as expected 
            var qry = queryable.Select(a => a.Cars.Select(b => b.Engine));

            foreach (IEnumerable<Engine> engines in qry)
                foreach (Engine engine in engines)
                {
                    Console.WriteLine("Engine Type {0}, Displacement {1}", engine.Type, engine.Displacement);
                }

            // Case B2          
            // Work as expected 
            var result = from a in queryable
                         from b in a.Cars
                         select b.Engine;

            foreach (Engine engine in result)
            {
                Console.WriteLine("Engine Type {0}, Displacement {1}", engine.Type, engine.Displacement);
            }

            // Case C1          
            // Work as expected 
            var drivers = queryable.Select(a => a.Cars.Select(b => b.Drivers));

            foreach (IEnumerable<IEnumerable<Driver>> listA in drivers)
                foreach (IEnumerable<Driver> listB in listA)
                    foreach (Driver driver in listB)
                    {
                        Console.WriteLine("Driver Name: {0}, {1}", driver.Name.First, driver.Name.Last);
                    }


            // Case C2          
            // Raises exception 'System.NotSupportedException' : {"$project or $group does not support {document}."}
            var resultDriver = from a in queryable
                               from b in a.Cars
                               from c in b.Drivers
                               select c;

            try
            {
                foreach (Driver driver in resultDriver)
                {
                    Console.WriteLine("Driver Name: {0}, {1}", driver.Name.First, driver.Name.Last);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Case C2 - failed : {0}", ex.Message);
            }

            // Case C3 - using SelectMany
            // Exception {"Unable to determine the serialization information for the collection selector in the tree: aggregate([]).SelectMany(a => a.Cars.SelectMany(b => b.Drivers))"}
            var driversC3 = queryable.SelectMany(a => a.Cars.SelectMany(b => b.Drivers));

            try
            {
                foreach (var x in driversC3)
                {
                    Console.WriteLine("x: {0}", x);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Case C3 - failed : {0}", ex.Message);
            }

            // Case D
            // Works as expected
            var cargoList = queryable.Select(a => a.Cars.Select(b => b.Trips.Select(c => c.Cargo)));

            foreach (IEnumerable<IEnumerable<IEnumerable<Cargo>>> listA in cargoList)
                foreach (IEnumerable<IEnumerable<Cargo>> listB in listA)
                    foreach (IEnumerable<Cargo> listC in listB)
                        foreach (Cargo cargo in listC)
                        {
                            Console.WriteLine("Cargo Name: {0}, Height: {1}", cargo.Info.Name, cargo.Size.Height);
                        }

            Console.ReadLine();
        }
    }
}
