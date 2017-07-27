using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODataMongoExpand.Models
{
    public class Person
    {
        [Key]
        [BsonId]
        public String _id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Description { get; set; }
        //[AutoExpand]
        public List<Trip> Trips { get; set; }
    }

    public class Trip
    {
        [Key]
        public String ID { get; set; }
        [Required]
        public String Name { get; set; }
    }

    public static class TestSettings
    {
        public const string dbName = "ODataMongoExpand";
        public const string colPeople = "People";

        public static void Initialize()
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(TestSettings.dbName);

            // Check if collection exists
            if (!db.ListCollections(new ListCollectionsOptions { Filter = new BsonDocument("name", TestSettings.colPeople) }).Any())
            {
                IMongoCollection<Person> collection = db.GetCollection<Person>(TestSettings.colPeople);

                collection.InsertOne(
                    new Person()
                    {
                        _id = "001",
                        Name = "Angel",
                        Trips = new List<Trip> {
                            new Trip()
                            {
                                ID = "0",
                                Name = "Trip 0"
                            },
                            new Trip()
                            {
                                ID = "1",
                                Name = "Trip 1"
                            }
                        }
                    });

                collection.InsertOne(
                    new Person()
                    {
                        _id = "003",
                        Name = "Elaine",
                        Description = "It has roots in a piece of classical Latin literature from 45 BC, making Lorems over 2000 years old."
                    });

                collection.InsertOne(
                    new Person()
                    {
                        _id = "002",
                        Name = "Clyde",
                        Description = "Contrary to popular belief, Lorem Ipsum is not simply random text.",
                        Trips = new List<Trip> {
                            new Trip()
                            {
                                ID = "3",
                                Name = "Trip 3"
                            },
                            new Trip()
                            {
                                ID = "4",
                                Name = "Trip 4"
                            }
                        }
                    });
            }
        }
    }
}