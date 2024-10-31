namespace ConsoleApp13
{
        internal class Person
        {
            public string ?FirstName { get; set; }
            public string ?LastName { get; set; }
            public int Balance { get; set; }

            public override string ToString()
            {
                return $"First Name - {FirstName}\nLast Name - {LastName}\nBalance - {Balance}$";
            }

    }

}
