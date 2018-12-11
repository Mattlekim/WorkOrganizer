using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrganizer.Data
{
    public class Street
    {
        public string Name;
        public string PostCode;
        public string Area;
        public string Notes;

        public int Id { get; private set; }

        public static List<Street> Streets = new List<Street>();

        /// <summary>
        /// Returns the required street
        /// Will Return Null if the street is no found
        /// </summary>
        /// <param name="id">the id for the street we want</param>
        /// <returns></returns>
        public static Street Find(int id)
        {
            foreach (Street street in Streets)
                if (street.Id == id)
                    return street; //found the street so return it

            return null; //not found so return null
        }
    }
}
