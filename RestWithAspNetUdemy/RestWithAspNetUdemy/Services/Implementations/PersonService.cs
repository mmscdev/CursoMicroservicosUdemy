using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();

            for (int i = 1; i <= 10; i++)
            {
                var person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person() { Id = 1, FirstName = "Name", LastName = "LastName", Address = "Uberlândia", Gender = "F" };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person() { Id = IncrementAndGet(), FirstName = $"Name {i}", LastName = "LastName", Address = "Uberlândia", Gender = "F" };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);

        }
    }
}
