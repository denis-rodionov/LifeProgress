using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Drawing;
using System.Data.Objects;
using Model2.Factories;

namespace Model2
{
    public class WeekWorker
    {
        const int MIN_BR = 0;
        const int MIN_BR2 = 0;
        const int MAX_BR = 255;
        const int BR_STEP = MAX_BR / 4;
        const int BR_STEP2 = 40;
        const int BASE_COLOR = 255;

        public static bool isWeekPast(Week week)
        {
            Week currentWeek = WeekFactory.createFakeWeek(DateTime.Now);
            return week < currentWeek;
        }

        /// <summary>
        /// Номер недели по дате
        /// </summary>
        /// <returns></returns>
        public static int getNumber(DateTime date)
        {
            CultureInfo myCI = new CultureInfo("ru-RU");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            return myCal.GetWeekOfYear(date, myCWR, myFirstDOW);
        }

        /// <summary>
        /// Returns collor depending on priority
        /// </summary>
        public static Color createColor(float p)
        {
            if (p < 0.1) return createColor1();
            else if (p < 0.2) return createColor2();
            else if (p < 0.3) return createColor3();
            else if (p < 0.4) return createColor4();
            else if (p < 0.5) return createColor5();
            else if (p < 0.6) return createColor6();
            else if (p < 0.7) return createColor7();
            else if (p < 0.8) return createColor8();
            else if (p < 0.9) return createColor9();
            else return createColor10();
        }

        public static Color createColor1() { return Color.FromArgb(0, MIN_BR2 + 4 * BR_STEP2, MAX_BR); }
        public static Color createColor2() { return Color.FromArgb(0, MIN_BR2 + 3 * BR_STEP2, MAX_BR); }
        public static Color createColor3() { return Color.FromArgb(0, MIN_BR2 + 2 * BR_STEP2, MAX_BR); }
        public static Color createColor4() { return Color.FromArgb(0, MIN_BR2 + 1 * BR_STEP2, MAX_BR); }
        public static Color createColor5() { return Color.FromArgb(0, MIN_BR2 + 0 * BR_STEP2, MAX_BR); }
        public static Color createColor6() { return Color.FromArgb(0, 0, MAX_BR); }
        public static Color createColor7() { return Color.FromArgb(0, 0, MIN_BR + 3 * BR_STEP); }
        public static Color createColor8() { return Color.FromArgb(0, 0, MIN_BR + 2 * BR_STEP); }
        public static Color createColor9() { return Color.FromArgb(0, 0, MIN_BR + 1 * BR_STEP); }
        public static Color createColor10() { return Color.FromArgb(0, 0, MIN_BR + 0 * BR_STEP); }

        /// <summary>
        /// return current week
        /// </summary>
        /// <param name="objectSet">Entity framework classes</param>
        public static Week getCurrentWeek(ModelEntities model)
        {
            return getWeek(DateTime.Now, model);
        }

        /// <summary>
        /// Returns week by date.
        /// Past week: find or create fake week
        /// Current or future: find or create week and save to db
        /// </summary>
        public static Week getWeek(DateTime date, ModelEntities model)
        {
            int number = getNumber(date);
            var res = model.Week.Where(w => w.Year == date.Year && w.Number == number);
            Week resWeek;

            if (res.Count() == 1)
                resWeek = res.Single();
            else if (res.Count() == 0)
            {
                Week temp = WeekFactory.createFakeWeek(date);
                if (temp.isOld())
                    resWeek = temp;
                else
                    resWeek = WeekFactory.createNewWeek(date, model);
            }
            else
                throw new Exception("There are " + res.Count() + " weeks with date " + date);

            if (WeekWorker.isCurrent(resWeek) && !resWeek.Active)
                resWeek.activate(model);

            return resWeek;
        }

        /// <summary>
        /// Returns week by date.
        /// Past week: find or create fake week
        /// Current or future: find or create week and save to db
        /// </summary>
        public static Week getWeek(int number, int year, ModelEntities model)
        {
            return getWeek(getWeekStartByNumber(number, year), model);
        }

        /// <summary>
        /// Is the parameter current week 
        /// </summary>
        public static bool isCurrent(Week week)
        {
            Week curWeek = WeekFactory.createFakeWeek(DateTime.Now);
            return curWeek.Year == week.Year && curWeek.Number == week.Number;
        }

        /// <summary>
        /// Gets the next calendar week (16 if the selWeek was 15).
        /// If the next week does not exist in db, creates the new one.
        /// </summary>
        public static Week getNextCalendarWeek(Week selWeek, ModelEntities model)
        {
            return getWeek(selWeek.getWeekStart().AddDays(7), model);
        }

        /// <summary>
        /// Gets the prevoious calendar week (14 if the selWeek was 15).
        /// If the previous week does not exist in db, creates the fake one.
        /// </summary>
        public static Week getPrevCalendarWeek(Week selWeek, ModelEntities model)
        {
            return getWeek(selWeek.getWeekStart().AddDays(-7), model);
        }

        /// <summary>
        /// Returns first day of week by it's number
        /// </summary>
        public static DateTime getWeekStartByNumber(int number, int year)
        {
            CultureInfo myCI = new CultureInfo("ru-RU");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            if (myCWR != CalendarWeekRule.FirstDay)
                throw new Exception("Не стандартное определение недель");

            DateTime firstJan = new DateTime(year, 1, 1);
            int dow = (new MyDayOfWeek(myCal.GetDayOfWeek(firstJan))).Id;
            return firstJan.AddDays(-dow + 1 + (number - 1) * 7);
        }

        
    }
}
