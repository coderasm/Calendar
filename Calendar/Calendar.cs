using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
  class Calendar
  {
    int COLUMN_WIDTH = 10;
    string[] daysOfWeek = { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
    private int month;
    int[,] days = new int[6, 7];
    public Calendar(int month)
    {
      this.month = month;
    }

    void SetMonth(int month)
    {
      this.month = month;
    }

    public void PrintCalendar()
    {
      PrintMonth();
      PrintDaysOfWeekHeader();
      PrintDaysOfWeek();
    }

    void PrintMonth()
    {
      var date = new DateTime(DateTime.Now.Year, this.month, 1);
      var toPrint = string.Format("{0," + (this.COLUMN_WIDTH * 3 + 2) + "}", date.ToString("MMMM, yyyy"));
      Console.WriteLine(toPrint);
      Console.WriteLine();
      Console.WriteLine();
    }

    void PrintDaysOfWeekHeader()
    {
      for (int i = 0; i < this.daysOfWeek.Length; i++)
      {
        var toPrint = string.Format("{0," + this.COLUMN_WIDTH + "}", this.daysOfWeek[i]);
        Console.Write(toPrint);
      }
      Console.WriteLine();
    }

    void PrintDaysOfWeek()
    {
      var daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
      var calendarRow = 0;
      //Store days of week in multidimensional array ordered by day of week
      for (int i = 0; i < daysInMonth; i++)
      {
        var dayDate = new DateTime(DateTime.Now.Year, month, i + 1);
        var dayOfWeek = dayDate.DayOfWeek;
        days[calendarRow, (int)dayOfWeek] = i + 1;
        if (dayOfWeek == DayOfWeek.Saturday)
          calendarRow++;
      }
      //Print the orderd days of week
      for (int i = 0; i < days.GetLength(0); i++)
      {
        for (int j = 0; j < days.GetLength(1) ; j++)
        {
          var toPrint = string.Format("{0," + this.COLUMN_WIDTH + "}", days[i, j] == 0 ? " " : days[i, j].ToString() );
          Console.Write(toPrint);
          if (j == (int)DayOfWeek.Saturday)
            Console.WriteLine();
        }
      }
    }
  }
}
