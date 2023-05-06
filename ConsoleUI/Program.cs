using GuestLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{

    // Get full name, email and get birthday from guests. At least one guest will arrive.
    // Print out the name, and a message they would like announced.
    // ensure email is a valid email. Give special seating to those 65 and older.
    internal class Program
    {
        private static List<GuestModel> guests = new List<GuestModel>();
        static void Main(string[] args)
        {
            GetGuestInformation();
            AnnounceGuests();

            Console.ReadLine();
        }

        private static void GetGuestInformation()
        {
            string moreGuests = "";
            do
            {
                GuestModel guest = new GuestModel();

                guest.FirstName = RetrieveDataFromGuests("What is your First name: ");
                guest.LastName = RetrieveDataFromGuests("What is your Last name: ");
                guest.Email = new MailAddress(RetrieveDataFromGuests("What is your Email Address: "));
                guest.Birthday = RetrieveBirthdayFromGuest("When is your Birthday (month/day/year): ");
                guest.MessageToHost = RetrieveDataFromGuests("What is your Message: ");
                moreGuests = RetrieveDataFromGuests("Will there be more guests (yes/no): ");
                
                Console.Clear();

                guests.Add(guest);

            } while (moreGuests.ToLower() != "no");
        }

        private static void AnnounceGuests()
        {
            foreach (GuestModel guest in guests)
            {
                Console.WriteLine(guest.GuestAnnouncement);
                SpecialSeating(guest);
            }

        }
        private static void SpecialSeating(GuestModel guest)
        {
            // converts TimeSpan object from DateTime.Now.Date - guest.Birthday to int and divides the result with 365 to find age of guest.
            int age = Convert.ToInt32(((DateTime.Now.Date - guest.Birthday).TotalDays / 365));
            if (age > 65)
            {
                Console.WriteLine($"{guest.FirstName}, please see Tim for escort.");
            }
        }

        private static string RetrieveDataFromGuests(string message)
        {
            Console.WriteLine(message);
            string data = Console.ReadLine();
            return data;
        }

        private static DateTime RetrieveBirthdayFromGuest(string message)
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
