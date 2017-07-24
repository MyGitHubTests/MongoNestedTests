using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODataRaw.Models
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
}