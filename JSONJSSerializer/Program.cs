using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONJSSerializer
{
    public class Company
    {
        public string Title { get; set; }
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public string Name { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }

    public enum EmployeeType
    {
        CEO,
        Developer,
        Analyst
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Load object with some sample data
            Company company = GetData();

            // Pass "company" object for conversion object to JSON string
            Console.WriteLine("Serializing data to JSON text file..");
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(company);

            // Write that JSON to txt file
            File.WriteAllText(Environment.CurrentDirectory + @"\JSON.txt", json);

            string jsonOut = File.ReadAllText(Environment.CurrentDirectory + @"\JSON.txt");

            Console.WriteLine("Deserializing data to JSON text file..");
            Company companyOut = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Company>(jsonOut);

            Console.WriteLine("Company title: " + companyOut.Title);
            foreach (var i in companyOut.Employees) 
            {
                Console.WriteLine("\tName: " + i.Name);
                Console.WriteLine("\tType: " + i.EmployeeType + "\n");
            }
  
        }

        public static Company GetData()
        {
            return new Company()
            {
                Title = "Wow Company Ltd",
                Employees = new List<Employee>()
            {
                new Employee(){ Name = "Mark", EmployeeType = EmployeeType.CEO },
                new Employee(){ Name = "Nanci", EmployeeType = EmployeeType.Developer },
                new Employee(){ Name = "Steve", EmployeeType = EmployeeType.Developer}
            }
            };
        }
    }
}
