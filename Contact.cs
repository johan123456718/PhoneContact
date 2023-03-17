using System;
using System.Windows.Media;

namespace P1PhoneJohan
{
    public class Contact : IEquatable<Contact>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Brush Color { get; set; }
        public bool Equals(Contact other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && PhoneNumber == other.PhoneNumber;
        }
    }
}
