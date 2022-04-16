using RealEstateWebApp.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateWebApp.Tests.Data
{
    public class Tasks
    {
        public static IEnumerable<Task> TenTasks()
           => Enumerable.Range(0, 10).Select(x => new Task());
    }
}
