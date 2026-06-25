using Flight_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System
{
    public class FlightContext
    {

        public List<Passenger> Passengers       { get; set; }

        public List<Pilot> Pilots                { get; set; }

        public List<Aircraft> Aircrafts          { get; set; }


        public List<Flight> Flights              { get; set; }



        public List<Booking> Bookings            { get; set; }

    }
}
