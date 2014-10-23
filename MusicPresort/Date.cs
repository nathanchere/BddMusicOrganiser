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
            // TODO: validate date
            throw new NotImplementedException();
        }

        // TODO:
        /*Equals for DateTime
             * ctor for datetime
             * ctor for string
             * comparion operators
             */
    }
}