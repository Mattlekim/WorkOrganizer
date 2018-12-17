using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrganizer.Data
{
    public struct JobType
    {
        private static List<string> Data = new List<string>();

        private string Value;

        public static void SetData(string[] input)
        {
            Data = input.ToList();
        }

        public static void SetData(string input)
        {
            SetData(input.Split(new char[] { '\n' }).ToArray());
        }

        public static List<string> GetData()
        {
            return Data;
        }

        public static implicit operator JobType(string s)
        {
            JobType job = new JobType()
            {
                Value = s,
            };
            return job;
        }

        public static implicit operator string(JobType job)
        {
            return job.Value;
        }

        public static bool operator ==(JobType job1, JobType job2)
        {
            if (job1.Value == job2.Value)
                return true;
            return false;
        }

        public static bool operator !=(JobType job1, JobType job2)
        {
            return !(job1 == job2);
        }

        public bool IsEmpty
        {
            get
            {
                if (Value == null || Value == string.Empty)
                    return true;
                return false;
            }
        }

        public static bool IsValid(string input)
        {
            if (Data.Contains(input))
                return true;
            return false;
        }

        public override string ToString()
        {
            if (IsEmpty)
                throw new Exception("value cannot be empty");
            return Value;
        }
    }
}
