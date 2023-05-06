using GuestLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestLibrary.Methods
{
    public class GuestsMethods
    {
        public static void AnnounceGuests(List<GuestModel> guests)
        {
            foreach (GuestModel guest in guests)
            {
                Console.WriteLine(guest.GuestAnnouncement);
                SpecialSeating(guest);
            }

        }
        public static void SpecialSeating(GuestModel guest)
        {
            // converts TimeSpan object from DateTime.Now.Date - guest.Birthday to int and divides the result with 365 to find age of guest.
            int age = Convert.ToInt32(((DateTime.Now.Date - guest.Birthday).TotalDays / 365));
            if (age > 65)
            {
                Console.WriteLine($"{guest.FirstName}, please see Tim for escort.");
            }
        }

        public static string RetrieveDataFromGuests(string message)
        {
            Console.WriteLine(message);
            string data = Console.ReadLine();
            return data;
        }

        public static DateTime RetrieveBirthdayFromGuest(string message)
        {
            Console.WriteLine(message);
            bool isValid = DateTime.TryParse(Console.ReadLine(), out DateTime birthday);
            while (isValid != true)
            {
                Console.WriteLine("That is not a valid format. Your format should be month/day/year. Please try again");
                Console.WriteLine(message);
                isValid = DateTime.TryParse(Console.ReadLine(), out birthday);
            }
            return birthday;
        }
    }
}
