using GraphQLServiceExample.Models;
using GraphQLServiceExample.Repository;

namespace GraphQLServiceExample.GraphQL
{
    public class Query
    {
        public Student? StudentGet(int id) => StudentRepo.Students.FirstOrDefault(x => x.Id == id);

        public List<Student> StudentGetAll() => StudentRepo.Students;
    }
}
