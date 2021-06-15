using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Jobs
{
    public static class RecurringTestJobs
    {

        [Obsolete]
        public static void Deneme()
        {
            RecurringJob.RemoveIfExists(nameof(job));
            //RecurringJob.AddOrUpdate<job>(nameof(job),
            //    x => x.Process(),
            //        "*/10 * * * * *", TimeZoneInfo.Local);
        }

    }

    public class job
    {
        public job()
        {
            Console.WriteLine("job");
        }

        public void Process() 
        {
            Console.WriteLine("process");

        }
    }
}
