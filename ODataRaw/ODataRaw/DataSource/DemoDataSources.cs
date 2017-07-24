using ODataRaw.Models;
using System.Collections.Generic;

namespace ODataRaw.DataSource
{
    public class DemoDataSources
    {
        private static DemoDataSources instance = null;
        public static DemoDataSources Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DemoDataSources();
                }
                return instance;
            }
        }
        public List<Person> People { get; set; }
        public List<Trip> Trips { get; set; }
        private DemoDataSources()
        {
            this.Reset();
            this.Initialize();
        }
        public void Reset()
        {
            this.People = new List<Person>();
            this.Trips = new List<Trip>();
        }
        public void Initialize()
        {
            this.Trips.AddRange(new List<Trip>()
            {
                new Trip()
                {
                    ID = "0",
                    Name = "Trip 0"
                },
                new Trip()
                {
                    ID = "1",
                    Name = "Trip 1"
                },
                new Trip()
                {
                    ID = "3",
                    Name = "Trip 3"
                },
                new Trip()
                {
                    ID = "2",
                    Name = "Trip 2"
                }
            });
            this.People.AddRange(new List<Person>
            {
                new Person()
                {
                    _id = "001",
                    Name = "Angel",
                    Trips = new List<Trip>{Trips[0], Trips[1]}
                },
                new Person()
                {
                    _id = "003",
                    Name = "Elaine",
                    Description = "It has roots in a piece of classical Latin literature from 45 BC, making Lorems over 2000 years old."
                },
                new Person()
                {
                    _id = "002",
                    Name = "Clyde",
                    Description = "Contrary to popular belief, Lorem Ipsum is not simply random text.",
                    Trips = new List<Trip>{Trips[2], Trips[3]}
                }
            });
        }
    }
}