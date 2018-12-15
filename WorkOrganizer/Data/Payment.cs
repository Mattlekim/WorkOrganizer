using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrganizer.Data
{
    public class Payment
    {
        /// <summary>
        /// an autonumber incrementer so that each record has a unique identifyer
        /// </summary>
        private static int AutoNumber = 0;

        /// <summary>
        /// set the id on creation of the instance
        /// </summary>
        private readonly int _id = AutoNumber++;

        /// <summary>
        /// the unique id for this record
        /// </summary>
        public int Id { get { return _id; } }

        public DateTime Date { get; private set; }
        public float Amount;
        public string Transaction_Id { get; set; }
        
        public PaymentType Type { get; private set; }
    }
}
