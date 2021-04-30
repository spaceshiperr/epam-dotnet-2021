using System;
using System.Globalization;

namespace Students
{
    class Student
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public Student(string email)
        {
            Email = email ?? throw new ArgumentNullException();
            FullName = GetFullNameByEmail(Email);
        }

        public Student(string name, string surname)
        {
            if (name is null | surname is null)
            {
                throw new ArgumentNullException();
            }
            
            FullName = name + ' ' + surname;
            Email = GetEmailByFullName(FullName);
        }
        
        private string GetFullNameByEmail(string email)
        {
            // redo using regex?
            string name = email.Split('.')[0];
            string surname = email.Split('.')[1].Split('@')[0];

            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            string nameCapitalized = textInfo.ToTitleCase(name);
            string surnameCapitalized = textInfo.ToTitleCase(surname);
            string fullName = nameCapitalized + ' ' + surnameCapitalized;

            return fullName;
        }

        private string GetEmailByFullName(string fullName)
        {
            string[] names = fullName.Split(' ');
            string email = (names[0] + '.' + names[1] + "@epam.com").ToLower();

            return email;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student other)
        {
            return other != null && other.Email == Email;
        }

        public override int GetHashCode()
        {
            return (Email, FullName).GetHashCode();
        }
    }
}
