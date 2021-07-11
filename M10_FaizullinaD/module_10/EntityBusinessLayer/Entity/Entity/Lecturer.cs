using System.Text.RegularExpressions;
using Entity.Additional;
using System.Collections.Generic;

namespace Entity.Entity
{
    public class Lecturer
    {
        private string email;
        
        public Lecturer(int id,
                       string firstName,
                       string lastName,
                       string email)
        {
            Id = id;
            Name = new Name(firstName, lastName);
            Email = email;
        }

        public int Id { get; }

        public Name Name { get; }

        public string Email
        {
            get { return email; }
            set
            {
                var regexString1 = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|";
                var regexString2 = @"(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                var regex = new Regex(regexString1 + regexString2, RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (regex.IsMatch(value))
                    email = value;
                else
                    throw new System.Exception();
            }
        }
    }
}
