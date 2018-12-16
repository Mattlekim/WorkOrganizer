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
        public int Frequence;

        public string Notes;
    }
}
