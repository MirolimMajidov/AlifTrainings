namespace Classes
{
    public class User
    {
        private string _lastName;

        public User()
        {
        }

        public User(string firstName)
        {
            FirstName = firstName;
        }

        public User(string firstName, string lastName) : this()
        {
            LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName
        {
            get
            {
                if (string.IsNullOrEmpty(_lastName))
                    return "Unknown";

                return _lastName;
            }
            set
            {
                if (value is not null) _lastName = value;
            }
        }

        public int Age { get; set; }

        ~User()
        {
        }
    }

    public class Student : User
    {
    }
    
    namespace SubClasses
    {
        public class Worker
        {
        }  
    }
}
