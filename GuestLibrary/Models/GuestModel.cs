using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GuestLibrary.Models
{
    public class GuestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public MailAddress Email{ get; set; }
        public string MessageToHost { get; set; }
        
        public string GuestAnnouncement
        {
            get
            {
                return $"{FirstName} {LastName}: {MessageToHost}";
            }
        }
    }
}
