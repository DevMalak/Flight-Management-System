using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
   public class Pilot
    {
        public int pilotId { get; set; }  //system generated

        public string pilotName { get; set; }  // user input

        public string pilotPhone { get; set; }  //user input 


        public string licenseNumber { get; set; } // user input 


        public int flightHours { get; set; }   //default value 0,Update after Departure


        public bool isAvailable { get; set; } // default value true

    }
}
