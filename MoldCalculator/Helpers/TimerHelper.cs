using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoldCalculator.Helpers
{
    public class TimerHelper
    {
        public static List<DateTime> CheckOffDay(DateTime dtStartDate, List<DateTime> offDayList, double workingDay)
        {
            List<DateTime> dtResultList = new List<DateTime>();
            DateTime dtFinishDate = dtStartDate.AddDays(workingDay);
            for (DateTime dt = dtStartDate.Date; dt <= dtFinishDate.Date; dt = dt.AddDays(1))
            {
                dtResultList.Add(dt);
            }
            do
            {
                dtStartDate = dtResultList.First();
                dtFinishDate = dtResultList.Last();
                for (DateTime dt = dtStartDate.Date; dt <= dtFinishDate.Date; dt = dt.AddDays(1))
                {
                    if ((offDayList.Select(a => a.Date).Contains(dt) == true && dtResultList.Contains(dt) == true) || dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dtResultList.Add(dtResultList.Last().AddDays(1));
                        dtResultList.Remove(dt);
                    }
                }
            }
            while (offDayList.Where(o => dtResultList.Contains(o.Date) == true).Count() > 0);
            return dtResultList;
        }
    }
}
