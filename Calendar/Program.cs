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
      //Print February
      var calendarFebruary = new Calendar(2);
      calendarFebruary.PrintCalendar();
      //Print December
      var calendarDecember = new Calendar(12);
      calendarDecember.PrintCalendar();
      Console.ReadKey(); ;
    }
  }
}
