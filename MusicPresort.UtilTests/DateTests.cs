using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace MusicPresort.UtilTests
{
    public class DateTests
    {
        [Theory]
        [InlineData(2010, 10, 5, 2010, 10, 5)]
        [InlineData(2000, 1, 1, 2000, 1, 1)]
        [InlineData(9999, 12, 31, 9999, 12, 31)]
        public void Equality_operator_returns_true(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);
            Assert.True(date1 == date2);
        }

        [Theory]
        [InlineData(2010, 10, 5, 2010, 10, 6)]
        [InlineData(2010, 10, 5, 2010, 11, 5)]
        [InlineData(2010, 10, 5, 2011, 10, 5)]
        public void Equality_operator_returns_false(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);
            Assert.False(date1 == date2);
        }

        [Theory]
        [InlineData(2010, 10, 5, 2010, 10, 5)]
        [InlineData(2010, 10, 5, 2010, 10, 6)]
        [InlineData(2010, 10, 5, 2010, 11, 5)]
        [InlineData(2010, 10, 5, 2011, 10, 5)]
        public void GreaterOrEqual_operator_returns_true(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);
            Assert.True(date1 >= date2);
        }

        [Theory]
        [InlineData(2010, 10, 4, 2010, 10, 5)]
        [InlineData(2010, 09, 5, 2010, 10, 5)]
        [InlineData(2009, 10, 5, 2010, 10, 5)]
        public void GreaterOrEqual_operator_returns_false(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);
            Assert.False(date1 >= date2);
        }

        [Theory]
        [InlineData(2010, 10, 5, 2010, 10, 5)]
        [InlineData(2010, 10, 4, 2010, 10, 5)]
        [InlineData(2010, 09, 5, 2010, 10, 5)]
        [InlineData(2009, 10, 5, 2010, 10, 5)]
        public void LessOrEqual_operator_returns_true(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);
            Assert.True(date1 <= date2);
        }

        [Theory]        
        [InlineData(2010, 10, 5, 2010, 10, 6)]
        [InlineData(2010, 10, 5, 2010, 11, 5)]
        [InlineData(2010, 10, 5, 2011, 10, 5)]
        public void LessOrEqual_operator_returns_false(int year1, int month1, int day1, int year2, int month2, int day2)
        {
            var date1 = new Date(year1, month1, day1);
            var date2 = new Date(year2, month2, day2);
            Assert.False(date1 <= date2);
        }
    }
}
