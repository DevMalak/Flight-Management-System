using Flight_Management_System.Models;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Threading.Channels;

namespace Flight_Management_System
{
  public class Program
    {
        //system storage(actual storage in memory for all lists)

        public static FlightContext context = new FlightContext
        {

            Passengers = new List<Passenger>(),

            Pilots = new List<Pilot>(),

            Aircrafts = new List<Aircraft>(),

            Flights = new List<Flight>(),

            Bookings = new List<Booking>(),

        };

        //there are 5 empty lists exits in memory under context

        public static void RegisterPassenger() //01
        {

            Console.WriteLine("\n===Register New Passenger===");

            Console.Write("Enter passenger name: ");
            string name = Console.ReadLine();


            Console.Write("Enter passenger email: ");
            string email = Console.ReadLine();


            Console.Write("Enter passenger phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter passenger passportNumber: ");
            string passportNumber = Console.ReadLine();

            Console.Write("Enter passenger nationality: ");
            string nationality = Console.ReadLine();


            int passengerId = context.Passengers.Count + 1;

            context.Passengers.Add(
                   new Passenger
                   {

                       // left side = Property from class
                       // right side = Variable value

                       passengerId = passengerId, // system generated

                       passengerName = name,      // user input

                       passengerEmail = email,    // user input 

                       passengerPhone = phone,    // user input

                       passportNumber = passportNumber,  //user input 

                       nationality = nationality, // user input

                   });

            Console.WriteLine($" passenger registered successfully. Assigned ID: {passengerId}");

        }



        public static void AddAircraft()  //02
        {

            Console.WriteLine("\n=== Register New Aircraft ===");

            Console.Write("Enter aircraft model: ");
            string model = Console.ReadLine();


            Console.Write("Enter aircraft total seats: ");
            int totalSeats = int.Parse( Console.ReadLine());


            int aircraftId = context.Aircrafts.Count + 1;

            context.Aircrafts.Add

             (
                new Aircraft
                {
                    aircraftId = aircraftId, //system generated

                    model = model,   // user input

                    totalSeats = totalSeats, // user input

                    isOperational = true,  // default value
                }

                );

            Console.WriteLine($" aircraft added successfully. Assigned ID: {aircraftId}");

        }


        public static void RegisterPilot() //03
        {


            Console.WriteLine("\n=== Register New Pilot ===");

            Console.Write("Enter pilot name: ");
            string name = Console.ReadLine();


            Console.Write("Enter pilot phone: ");
            string phone = Console.ReadLine();


            Console.Write("Enter pilot license Number: ");
            string licenseNumber = Console.ReadLine();

         
            int pilotId = context.Pilots.Count + 1;

            context.Pilots.Add(
                   new Pilot
                   {

                       // left side = Property from class
                       // right side = Variable value

                       pilotId = pilotId,         // system generated

                       pilotName = name,      // user input

                       pilotPhone = phone,    // user input 

                       licenseNumber = licenseNumber,    // user input

                       flightHours = 0,  //default value 

                       isAvailable = true, //default value

                   });

            Console.WriteLine($" pilot registered successfully. Assigned ID: {pilotId}");

        }



        public static void ViewAllFlights() //04
        {

            Console.WriteLine("\n=== All Registered Flights ===");

            foreach(Flight f in context.Flights)

            {

                Console.WriteLine($"Flight Code: {f.flightCode} | Origin: {f.origin} | Destination: {f.destination}" +
                         $" | Departure Date: {f.departureDate} | Departure Time: {f.departureTime}" +
                         $" | Available Seats: {f.availableSeats} | Ticket Price: {f.ticketPrice}" +
                         $" | Status: {f.status}");
            }
        }


        public static void ScheduleFlight() //05
        {
            Console.WriteLine("\n=== Schedule Flight ===");

            foreach (Aircraft a in context.Aircrafts)

            {
                Console.WriteLine($"ID: {a.aircraftId} | Model: {a.model} | Seats: {a.totalSeats}");

            }
            Console.WriteLine("Enter Aircraft ID: ");
            int aircraftId = int.Parse(Console.ReadLine());

            Aircraft aircraft = context.Aircrafts
                .FirstOrDefault(a => a.aircraftId == aircraftId);

            if (aircraft == null || aircraft.isOperational == false)
            {
                Console.WriteLine("Aircraft not available");
                return;
            }
            Console.WriteLine("Enter pilot ID: ");
            int pilotId = int.Parse(Console.ReadLine());

            Pilot pilot = context.Pilots.FirstOrDefault(p => p.pilotId == pilotId);

            if (pilot == null || pilot.isAvailable == false)
            {

                Console.WriteLine("Pilot not available");

                return;
            }

            Console.WriteLine(" Enter origin: ");
            string origin = Console.ReadLine();


            Console.WriteLine(" Enter destination: ");
            string destination = Console.ReadLine();

            Console.WriteLine(" Enter departure date: ");
            string date = Console.ReadLine();


            Console.WriteLine(" Enter departure time: ");
            string time = Console.ReadLine();


            Console.WriteLine(" Enter ticket price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter flight duration: ");
            int flightDuration = int.Parse(Console.ReadLine());

            int flightId = context.Flights.Count + 1;
            string flightCode = "FL-" + flightId;


            context.Flights .Add(
             new Flight
             {
                flightId = flightId,

                flightCode = flightCode,

               aircraftId = aircraftId,

                pilotId = pilotId,

                origin = origin,

                destination = destination,

                departureDate = date,

                departureTime = time,

                ticketPrice = price,

                availableSeats = aircraft.totalSeats,

                status = "Scheduled",  // Scheduled | Departed | Cancelled

                 flightDuration = flightDuration,
             });

            pilot.isAvailable = false;

            Console.WriteLine($"Flight scheduled successfully. Code: {flightCode}");
        }



        public static void BookFlight() //06
        {


        }

        public static void CancelBooking() //07
        {


        }

        public static void DepartFlight() //08
        {

        }

        public static void CancelFlight() //09
        {

        }

        public static void PassengerBookingHistory() //10
        {

        }

        public static void FlightRevenueAndLoadFactorReport() //11
        {

        }


        static void Main(string[] args)
        {

            bool exit = false;

            while (exit == false)

            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("Flight Management System");
                Console.WriteLine("===============================================");
                Console.WriteLine("1  - Register a Passenger");
                Console.WriteLine("2  - Add an Aircraft");
                Console.WriteLine("3  - Register a Pilot");
                Console.WriteLine("4  - View All Flights");
                Console.WriteLine("5  - Schedule a Flight");
                Console.WriteLine("6  - Book a Fligh");
                Console.WriteLine("7  - Cancel a Booking");
                Console.WriteLine("8  - Depart a Flight");
                Console.WriteLine("9  - Cancel a Flight");
                Console.WriteLine("10  - Passenger Booking History");
                Console.WriteLine("11  - Flight Revenue & Load Factor Report");
                Console.WriteLine("0  - Exit");
                Console.WriteLine("===============================================");
                Console.WriteLine("Select option:");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: RegisterPassenger(); break;

                    case 2: AddAircraft(); break;

                    case 3: RegisterPilot(); break;

                    case 4: ViewAllFlights(); break;

                    case 5: ScheduleFlight(); break;

                    case 6: BookFlight(); break;

                    case 7: CancelBooking(); break;

                    case 8: DepartFlight(); break;

                    case 9: CancelFlight(); break;

                    case 10: PassengerBookingHistory(); break;

                    case 11: FlightRevenueAndLoadFactorReport(); break;

                    case 0: exit = true; break;
                    default: Console.WriteLine("Invalid option.Please try again."); break;
                }
                if (!exit)

                {

                    Console.WriteLine("\nPress any Key to continue..");
                    Console.ReadKey();
                    Console.Clear();

                }

            }

            Console.WriteLine("Goodbye");
                        
    }
    }
}
