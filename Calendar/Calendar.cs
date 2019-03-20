using System;

namespace Calendar
{
  class Calendar
  {
    int COLUMN_WIDTH = 10;
    string[] daysOfWeek = { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
    string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    int[] dayOfWeekMonthBegins = { 2, 5, 5, 1, 3, 6, 1, 4, 0, 2, 5, 0 };
    int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    private int month;
    //multidimensional array to hold days of month in calendar order
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
      //print entered month and current year
      var toPrint = string.Format("{0," + (this.COLUMN_WIDTH * 3 + 2) + "}", months[month - 1] + ", 2019");
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
      var SATURDAY = 6;
      var daysInMonth = daysInMonths[month - 1];
      var calendarRow = 0;
      //Store days of week in multidimensional array ordered by day of week
      for (int i = 1; i <= daysInMonth; i++)
      {
        //Find difference in days fromt the first of the month
        var diffFromFirst = i - 1;
        //Offset is the index day of the week for the first day of the month
        var offset = dayOfWeekMonthBegins[month - 1];
        var dayOfWeek = (diffFromFirst + offset) % 7;
        days[calendarRow, dayOfWeek] = i;
        if (dayOfWeek == SATURDAY)
          calendarRow++;
      }
      //Print days of month ordered by days of week
      for (int i = 0; i < days.GetLength(0); i++)
      {
        for (int j = 0; j < days.GetLength(1) ; j++)
        {
          var toPrint = string.Format("{0," + this.COLUMN_WIDTH + "}", days[i, j] == 0 ? " " : days[i, j].ToString() );
          Console.Write(toPrint);
          if (j == SATURDAY)
            Console.WriteLine();
        }
      }
    }
  }
}
