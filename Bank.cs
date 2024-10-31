
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal partial class Bank
    {
        List<Person> users = new List<Person>()
        {
            // should go in C Grade < 3k
            new Person() { FirstName = "Gio", LastName = "Mamaladze", Balance = 2500 },
            new Person() { FirstName = "Alice", LastName = "Smith", Balance = 1500 },
            new Person() { FirstName = "Bob", LastName = "Johnson", Balance = 800 },
            
            // should go in B Grade > 3k < 10k
            new Person() { FirstName = "Charlie", LastName = "Brown", Balance = 5000 },
            new Person() { FirstName = "David", LastName = "Wilson", Balance = 7000 },
            new Person() { FirstName = "Eva", LastName = "Davis", Balance = 9000 },

            // should go in A Grade > 10k
            new Person() { FirstName = "Frank", LastName = "Miller", Balance = 15000 },
            new Person() { FirstName = "Grace", LastName = "Garcia", Balance = 12000 },
            new Person() { FirstName = "Hank", LastName = "Martinez", Balance = 20000 }
        };

        // CreateGrades() working on this list, in this case 3 Folder will be created
        List<string> grades = new List<string>()
        {
            "A Grade", "B Grade", "C Grade"
        };

        // Creates Main Folder Named Bank, only creates once 
        public DirectoryInfo CreateDir()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Bank";
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
            {
                dir.Create();
            }
            return dir;
        }
        
        // Creates Folders from grade[] List | Should take CreateDir() as argument or Parent Folder Directory
        public void CreateGrades(DirectoryInfo parentDir)
        {
            DirectoryInfo gradesDir;
            foreach (var item in grades)
            {
                gradesDir = parentDir.CreateSubdirectory($"{item}");
            }
        }

        // Creates user txt files in grades folder based on user[] List
        public void CreateUsers(DirectoryInfo parentDir)
        {
            DirectoryInfo grades = parentDir;
            var grad = grades.GetDirectories();
            
            foreach (var item in grad)
            {
                Console.WriteLine(item);

            }

            // Initializing all 3 grade
            var allGrade = grad;
            // Stores 1 grade
            DirectoryInfo grade = grad[0];
            foreach (var item in users)
            {

                if(item.Balance < 3000)
                    grade = grad.FirstOrDefault(o => o.Name == "C Grade");

                else if(item.Balance > 3000 && item.Balance < 10000)
                    grade = grad.FirstOrDefault(o => o.Name == "B Grade");

                else if(item.Balance > 10000)
                    grade = grad.FirstOrDefault(o => o.Name == "A Grade");


                var userFileName = $"{item.FirstName + " " + item.LastName}.txt";
                StreamWriter stream = File.CreateText(grade.FullName + $"/{userFileName}") ;
                stream.WriteLine(item.ToString());

                stream.Dispose();
            }
        }
        public void CreateUsers1(DirectoryInfo parentDir)
        {
            DirectoryInfo[] grades = parentDir.GetDirectories();
            
            // Create a dictionary to map grades to their corresponding directories
            var gradeDirectories = grades.ToDictionary(g => g.Name);

            foreach (var item in users)
            {
                DirectoryInfo grade;

                // Determine the user's grade based on balance
                if (item.Balance < 3000)
                {
                    grade = gradeDirectories.GetValueOrDefault("C Grade");
                }
                else if (item.Balance < 10000)
                {
                    grade = gradeDirectories.GetValueOrDefault("B Grade");
                }
                else
                {
                    grade = gradeDirectories.GetValueOrDefault("A Grade");
                }

                if (grade != null)
                {
                    var userFileName = $"{item.FirstName} {item.LastName}.txt";

                    // Use 'using' to ensure the StreamWriter is disposed of properly
                    using (StreamWriter stream = File.CreateText(Path.Combine(grade.FullName, userFileName)))
                    {
                        stream.WriteLine(item.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"Grade directory not found for user: {item.FirstName} {item.LastName}");
                }
            }
        }
    }
}
