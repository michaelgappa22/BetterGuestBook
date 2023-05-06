using GuestLibrary.Models;
using GuestLibrary.Methods;
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
            GuestsMethods.AnnounceGuests(guests);

            Console.ReadLine();
        }

        private static void GetGuestInformation()
        {
            string moreGuests = "";
            do
            {
                GuestModel guest = new GuestModel();

                guest.FirstName = GuestsMethods.RetrieveDataFromGuests("What is your First name: ");
                guest.LastName = GuestsMethods.RetrieveDataFromGuests("What is your Last name: ");
                guest.Email = new MailAddress(GuestsMethods.RetrieveDataFromGuests("What is your Email Address: "));
                guest.Birthday = GuestsMethods.RetrieveBirthdayFromGuest("When is your Birthday (month/day/year): ");
                guest.MessageToHost = GuestsMethods.RetrieveDataFromGuests("What is your Message: ");
                moreGuests = GuestsMethods.RetrieveDataFromGuests("Will there be more guests (yes/no): ");
                
                Console.Clear();

                guests.Add(guest);

            } while (moreGuests.ToLower() != "no");
        }

    }
}
