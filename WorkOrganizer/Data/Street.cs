using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrganizer.Data
{
    public class Street
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

        public string Name;
        public string PostCode;
        public string Area;
        public string Notes;

        public static List<Street> Streets { get; private set; } = new List<Street>();

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

        public static ActionState Add(Street street)
        {
            foreach (Street s in Streets)
                if (s.Name == street.Name)
                    if (s.Area == street.Area)
                    {
#if DEBUG
                        Console.WriteLine($"Adding street '{street.Name}, {street.Area}' failed: {ActionState.Failure_Entry_Alread_Exits}");
#endif
                        return ActionState.Failure_Entry_Alread_Exits;
                    }
            Streets.Add(street);
#if DEBUG
            Console.WriteLine($"'{street.Name}, {street.Area}' added.");
#endif
            return ActionState.Success;
        }

        public static void SetUpDebugData()
        {
            Console.WriteLine("Creating Debug Streets");
            Add(new Street() { Name = "test data", Area = "rotherham" });
            Add(new Street() { Name = "becket cresent", Area = "rotherham" });
            Add(new Street() { Name = "main street", Area = "rotherham" });
            Console.WriteLine("Complete");
        }
    }
}
