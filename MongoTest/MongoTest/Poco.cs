// Created with http://json2csharp.com/
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    public class Engine
    {
        public string Type { get; set; }
        public double Displacement { get; set; }
    }

    public class Body
    {
        public string Style { get; set; }
        public string Color { get; set; }
    }

    public class Name
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Contact
    {
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class Driver
    {
        public Name Name { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
    }

    public class Mileage
    {
        public double Start { get; set; }
        public double End { get; set; }
    }

    public class Period
    {
        public string Start { get; set; }
        public string End { get; set; }
    }

    public class Size
    {
        public double Height { get; set; }
        public double Wight { get; set; }
        public double Lenght { get; set; }
    }

    public class Info
    {
        public double Weight { get; set; }
        public string Name { get; set; }
    }

    public class Cargo
    {
        public Size Size { get; set; }
        public Info Info { get; set; }
    }

    public class Trip
    {
        public string Note { get; set; }
        public Mileage Mileage { get; set; }
        public Period Period { get; set; }
        public List<Cargo> Cargo { get; set; }
    }

    public class Car
    {
        public Engine Engine { get; set; }
        public Body Body { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Trip> Trips { get; set; }
    }

    public class Poco
    {
        public ObjectId Id { get; set; }
        public List<Car> Cars { get; set; }
    }
}
