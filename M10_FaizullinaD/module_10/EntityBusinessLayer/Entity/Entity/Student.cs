using System.Text.RegularExpressions;
using Entity.Additional;

namespace Entity.Entity
{
    public class Student
    {
        private string email;

        private string phoneNumber;

        public Student(int id, 
                       string firstName,
                       string lastName,
                       string email,
                       string phoneNumber)
        {
            Id = id;
            Name = new Name(firstName, lastName);
            Email = email;
            PhoneNumber = phoneNumber;
        }
        
        public int Id { get; }

        public Name Name { get; set; }

        public string Email 
        { 
            get { return email; }
            set
            {
                var regexString1 = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|";
                var regexString2 = @"(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                var regex = new Regex(regexString1 + 
                                      regexString2,RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (regex.IsMatch(value))
                    email = value;
                else
                    throw new System.Exception();
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                var regex = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
                if (regex.IsMatch(value))
                    phoneNumber = value;
                else
                    throw new System.Exception();
            }
        }
    }
}
