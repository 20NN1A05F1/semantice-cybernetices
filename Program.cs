using Ical.Net;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ICSFileReader
{
    class Program
    {
        static async Task Main()
        {
            // Read Calendar Online
            var olineSchedule = WebRequest.Create("https://github.com/20NN1A05F1/semantice-cybernetices");
            var response = await olineSchedule.GetResponseAsync().ConfigureAwait(false);
            var stream = response.GetResponseStream();
            
            var calendar = Calendar.Load(stream);

            // Load the .ics file localy
            // var calendar = Calendar.Load(File.OpenRead("cours.ics"));

            // Get events
            var events = calendar.Events;

            // Order events by Start Date
            var events_sorted = events.OrderBy(e => e.DtStart.AsSystemLocal);

            foreach (var evt in events_sorted)
            {
                // C# Target-typed new expressions
                Cours cours = new(evt);
                Console.WriteLine(cours);
                Console.WriteLine("=================================");
            }
        }

    }
}
