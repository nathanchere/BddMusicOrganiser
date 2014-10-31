using System;

namespace MusicPresort
{
    public class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public override bool Equals(object obj)
        {
            var target = obj as Date;
            return target != null
                   && target.Year == this.Year
                   && target.Month == this.Month
                   && target.Day == this.Day;
        }

        public Date() { }

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;

            if (!IsValid())
            {
                Year = 0;
                Month = 0;
                Day = 0;
                throw new ArgumentException("Input is not a valid date");
            }
        }

        /// <remarks>
        /// Must be in format "yyyy-MM-dd" to be valid
        /// </remarks>        
        public Date(string input)
        {
            if (input == null) throw new ArgumentNullException("Cannot create a Date from a null string");
            var inputs = input.Split('-');
            if(inputs.Length != 3)
                throw new ArgumentException("Input is not in a valid format");
            
            DateTime.Parse(input);
            
            Year = int.Parse(inputs[0]);
            Month = int.Parse(inputs[1]);
            Day = int.Parse(inputs[2]);
        }

        public Date(DateTime input)
        { 
            Year = input.Year;
            Month = input.Month;
            Day = input.Day;
        }

        public bool IsValid()
        {
            DateTime temp;
            return DateTime.TryParse(this.ToString(), out temp);
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Year, Month, Day);
        }

        public bool Equals(Date date2)
        {                       
            if (date2 == null) return false;
            var date1 = this;

            if (ReferenceEquals(date1, date2)) return true;

            if (date1.Year != date2.Year) return false;
            if (date1.Month != date2.Month) return false;
            if (date1.Day != date2.Day) return false;

            return true;
        }        

        public override int GetHashCode()
        {
            return int.Parse(string.Format("{0}{1}{2}", Month, Day, Year));
        }        

        public static bool operator ==(Date date1, Date date2)
        {
            return Equals(date1, date2);
        }

        public static bool operator !=(Date date1, Date date2)
        {
            return !Equals(date1, date2);
        }

        public static bool operator >(Date date1, Date date2)
        {
            if (date1 as object == null || date2 as object == null) return false;
            if (Equals(date1, date2)) return false;

            if (date2.Year > date1.Year) return false;
            if (date2.Year < date1.Year) return true;

            if (date2.Month > date1.Month) return false;
            if (date2.Month < date1.Month) return true;

            if (date2.Day > date1.Day) return false;
            if (date2.Day < date1.Day) return true;

            return false;
        }

        public static bool operator <(Date date1, Date date2)
        {
            if (date1 as object == null || date2 as object == null) return false;
            if (Equals(date1, date2)) return false;


            if (date2.Year > date1.Year) return true;
            if (date2.Year < date1.Year) return false;

            if (date2.Month > date1.Month) return true;
            if (date2.Month < date1.Month) return false;

            if (date2.Day > date1.Day) return true;
            if (date2.Day < date1.Day) return false;            

            return false;
        }

        public static bool operator <=(Date date1, Date date2)
        {
            if (date1 as object == null || date2 as object == null) return false;
            return Equals(date1, date2) || date1 < date2;
        }

        public static bool operator >=(Date date1, Date date2)
        {
            if (date1 as object == null || date2 as object == null) return false;
            return Equals(date1, date2) || date1 > date2;
        }
    }
}