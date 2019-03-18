using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 A calendar which prints the days of the month in a calendar format.
   */
namespace Calendar
{
  class Program
  {
    static void Main(string[] args)
    {
      var monthsInYear = 12;
      for (int i = 1; i <= monthsInYear; i++)
      {
        var calendar = new Calendar(i);
        calendar.PrintCalendar();
      }
      Console.ReadKey(); ;
    }
  }
}
