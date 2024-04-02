using GraphQLServiceExample.Models;

namespace GraphQLServiceExample.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        public Student StudentAdded([EventMessage] Student student) => student;

        [Subscribe]
        public int StudentDeleted([EventMessage] int id) => id;
    }
}
