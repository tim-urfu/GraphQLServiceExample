using GraphQLServiceExample.Dtos;
using GraphQLServiceExample.Models;
using GraphQLServiceExample.Repository;
using HotChocolate.Subscriptions;

namespace GraphQLServiceExample.GraphQL
{
    public class Mutation
    {
        public async Task<Student> StudentAdd(StudentAddDto model, [Service] ITopicEventSender sender)
        {
            var id = StudentRepo.Students.Count > 0 ? StudentRepo.Students.Max(x => x.Id) + 1 : 1;

            var student = new Student()
            {
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CreatedAt = DateTime.Now,
            };

            StudentRepo.Students.Add(student);

            await sender.SendAsync("StudentAdded", student);

            return student;
        }

        public bool StudentDelete(int id)
        {
            StudentRepo.Students.RemoveAll(x => x.Id == id);

            return true;
        }
    }
}
