using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_1k
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var p1 = new Plane("Moscow", 123456, DateTime.Now.AddMinutes(30));
            var p2 = new Plane("London", 123457, DateTime.Now.AddMinutes(120));
            var airport = new Airport(p1, p2);
            Console.WriteLine(airport[123456]);
            foreach (var fly in airport.FlightsInTheNextHour(DateTime.Now))
                Console.WriteLine(fly);
            foreach (var fly in airport.FlightsInTheDestination("London"))
                Console.WriteLine(fly);
            Console.WriteLine(Airport.CompareTwoFlys(p1, p2));
        }
    }

    public class Plane
    {
        public Plane(string destination, int flightNumber, DateTime departureTime)
        {
            Destination = destination;
            FlightNumber = flightNumber;
            DepartureTime = departureTime;
        }

        public string Destination { get; }
        public int FlightNumber { get; }
        public DateTime DepartureTime { get; }


        public override string ToString() =>
            string.Format($"Desination: {Destination}, " +
                          $"FlightNumber: {FlightNumber}, " +
                          $"DepartureTime: {DepartureTime}");
    }

    public class Airport
    {
        private readonly IEnumerable<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes;
        }

        public Airport(params Plane[] planes)
        {
            this.planes = planes;
        }

        public string this[int flightNumber]
        {
            get
            {
                return planes
                    .FirstOrDefault(x => x.FlightNumber == flightNumber)?
                    .ToString();
            }
        }

        public IEnumerable<string> FlightsInTheNextHour(DateTime time)
        {
            return planes
                .Where(x => x.DepartureTime <= time.AddHours(1))
                .OrderBy(x => x.DepartureTime)
                .Select(x => x.ToString());
        }

        public IEnumerable<string> FlightsInTheDestination(string destination)
        {
            return planes
                .Where(x => x.Destination == destination)
                .OrderBy(x => x.DepartureTime)
                .Select(x => x.ToString());
        }

        public static int CompareTwoFlys(Plane p1, Plane p2) =>
            p1.DepartureTime.CompareTo(p2.DepartureTime);
    }
}