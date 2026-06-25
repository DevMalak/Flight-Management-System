using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Flight
    {

        public int flightId { get; set; } //system generated


        public string flightCode { get; set; } //system generated



        public int aircraftId { get; set; } //user input ( from aircraft list)


        public int pilotId { get; set; } // user input  ( from poilt list)


        public string origin { get; set; } // user input



        public string destination { get; set; } // user input 


        public string departureDate { get; set; } // usrr input 


        public string departureTime { get; set; } // user input 


        public decimal ticketPrice { get; set; } // user input


        public int availableSeats { get; set; } //system calculatef from titalseats


        public string status { get; set; } // default value "Scheduled" | "Departed" | "Cancelled" 


        public int  flightDuration{ get; set; }//user input 
    }
}
