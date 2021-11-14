using System;
using System.Threading.Tasks;

namespace ObserverPatternExample1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cipri = new JobSeeker("Cipri");
            var andreea = new JobSeeker("Andreea");

            var agency = new EmploymentAgency();
            agency.Notify += cipri.OnJobPosted;
            agency.Notify += andreea.OnJobPosted;

            agency.AddJob("Software Engineer");
            await Task.Delay(1000);
            Console.WriteLine("---------------------");
            agency.AddJob("Software Tester");
            await Task.Delay(1000);
            Console.WriteLine("---------------------");
            agency.Notify -= cipri.OnJobPosted;
            agency.AddJob("Software Architect");
        }
    }
}
