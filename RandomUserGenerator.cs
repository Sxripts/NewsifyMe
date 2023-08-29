using System;

namespace NewsifyMe
{
    public class RandomUserGenerator
    {
        public (string, string) GenerateRandomUser()
        {
            string firstName = GenerateRandomName("first");
            string lastName = GenerateRandomName("last");

            return (firstName, lastName);
        }

        private string GenerateRandomName(string type)
        {
            Random rand = new Random();
            string[] firstNames = { "Alice", "Bob", "Charlie", "Dave", "Eva" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones" };

            string name = (type == "first") ? firstNames[rand.Next(firstNames.Length)] : lastNames[rand.Next(lastNames.Length)];
            return name;
        }
    }
}