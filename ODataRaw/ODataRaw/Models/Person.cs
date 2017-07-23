﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;

namespace ODataRaw.Models
{
    public class Person
    {
        [Key]
        [BsonId]
        public String _id { get; set; }
        //public String ID { get; set; }
        [Required]
        public String Name { get; set; }
        public String Description { get; set; }
        //[AutoExpand]
        public List<Trip> Trips { get; set; }
    }
}