using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrganizer.Data
{
    public class Customer
    {
        public int Id { get; private set; }

        public string FName, SName;

        public string Notes;

        /// <summary>
        /// the house Name / number
        /// </summary>
        public string HouseName;

        /// <summary>
        /// this links it to the street it is on
        /// </summary>
        public int StreetId;

        public List<Job> Jobs { get; private set; } = new List<Job>();
     
    }
}
