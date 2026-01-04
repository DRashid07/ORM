namespace OrmPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using (var coxtext = new Data.AppDbContext())
            {
                var newStudent = new Models.Student
                {
                    Name = "John Doe",
                    Description = "A new student",
                    Age = 20
                };  
                coxtext.Students.Add(newStudent);
                coxtext.SaveChanges();
            }
            using (var context = new Data.AppDbContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Name == "John Doe");
                if (student != null)
                {
                    student.Age = 21;
                    context.SaveChanges();
                }
            }
            using (var context = new Data.AppDbContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Name == "John Doe");
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
            }
            using (var context = new Data.AppDbContext())
            {
                var student = context.Students.Where(context => context.Age > 21 && context.Contains("a").ToList());
            }
            using (var context = new Data.AppDbContext())
            {
                var students = context.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Description: {student.Description}, Age: {student.Age}");
                }
            }
        }
    }
}
