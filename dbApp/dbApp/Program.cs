using System;
using System.Linq;
using dbApp.DataBase;
using dbApp.Model;
using Microsoft.EntityFrameworkCore;

namespace dbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new DbAppContext();
            if (!dbContext.Employees.Any())
            {

                var e1 = new Employee()
                {
                    Name = "Lev",
                    MiddleName = "Davidovich",
                    Surname = "Bronstein",
                    Email = "123@mail.ru"
                };
                var e2 = new Employee()
                {
                    Name = "Ioseb",
                    MiddleName = "Vissarionovich",
                    Surname = "Dzhugashvili",
                    Email = "qwe@mail.ru"
                };
                var e3 = new Employee()
                {
                    Name = "John",
                    Surname = "Smith",
                    Email = "who@gmail.com"
                };
                dbContext.Employees.AddRange(e1, e2, e3);

                var p1 = new Project()
                {
                    Name = "BotNet",
                    Customer = "Skynet",
                    Executor = "Humanity",
                    Priority = 10,
                    StartDate = DateTime.Now
                };
                var p2 = new Project()
                {
                    Name = "AcademySite",
                    Customer = "mkb",
                    Executor = "Students.co",
                    Priority = 3,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.MaxValue
                };
                dbContext.Projects.AddRange(p1, p2);

                dbContext.SaveChanges();

                p1.ProjectEmployees.Add(new ProjectEmployee() { EmployeeId = e1.Id, ProjectId = p1.Id });
                p1.ProjectEmployees.Add(new ProjectEmployee() { EmployeeId = e2.Id, ProjectId = p1.Id });
                p1.ProjectEmployees.Add(new ProjectEmployee() { EmployeeId = e3.Id, ProjectId = p1.Id });
                p2.ProjectEmployees.Add(new ProjectEmployee() { EmployeeId = e3.Id, ProjectId = p2.Id });

                dbContext.SaveChanges();
            }

            var employees = dbContext.Employees.Include(e => e.ProjectEmployees).ThenInclude(pe => pe.Project).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"Full name: {employee.Name} {employee.MiddleName} {employee.Surname}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine("Working on projects:");
                var projects = employee.ProjectEmployees.Select(pe => pe.Project).ToList();
                foreach (var project in projects)
                {
                    Console.WriteLine($"\n\tName: {project.Name}");
                    Console.WriteLine($"\tCustomer: {project.Customer}");
                    Console.WriteLine($"\tExecutor: {project.Executor}");
                    Console.WriteLine($"\tManager: {project.Manager.Name}  {project.Manager.MiddleName} {project.Manager.Surname}");
                    Console.WriteLine($"\tPriority: {project.Priority}");
                    Console.WriteLine($"\tStartDate: {project.StartDate}");
                    Console.WriteLine($"\tEndDate: {project.EndDate}");
                }

            }
        }
    }
}
