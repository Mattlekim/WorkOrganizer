using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrganizer.Data
{
    public class Job
    {
        public JobType Type { get; private set; }

        /// <summary>
        /// Weather we repeate the job or not
        /// </summary>
        public Repeatable RepeateJob;

        /// <summary>
        /// frequence in weeks
        /// </summary>
        public int Frequency;

        public string Notes;

        public float Price;

        public Job(JobType type, Repeatable repeateJob, int frequency, float price, string notes)
        {
            Type = type;
            RepeateJob = repeateJob;
            if (RepeateJob == Repeatable.Yes)
                Frequency = frequency;
            else
                Frequency = 0;
            Price = price;
            Notes = notes;
        }
    }
}
