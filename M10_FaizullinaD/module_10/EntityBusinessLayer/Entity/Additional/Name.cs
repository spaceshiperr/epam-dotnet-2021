﻿namespace Entity.Additional
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
