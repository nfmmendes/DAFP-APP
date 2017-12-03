using System;
using System.Collections.Generic;

namespace SolverClientComunication
{
    class Time : IComparable<Time>
    {
        private DateTime DateTime { get; set; }

        public int Hour
        {
            get => DateTime.Hour;
            set
            {
                if (value < 0 || value > 23) throw new Exception("Out of limit hour");
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day,value,Minute,Second,Millisecond);

            }
        }

        public int Minute
        {
            get => DateTime.Minute;
            set
            {
                if(value > 59 || value <0) throw new Exception("Out of limit minute");
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, Hour, value, Second,Millisecond);
            }

        }

        public int Second
        {
            get => DateTime.Second;
            set
            {
                if (value > 59 || value < 0) throw new Exception("Out of limit second");
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, Hour, Minute, value, Millisecond);
            }
        }

        public int Millisecond
        {
            get => DateTime.Millisecond;
            set
            {
                if (value > 999 || value < 0) throw new Exception("Out of limit millisecond");
                DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, Hour, Minute, Second, value);
            }
        }


        public Time(int hours, int minutes=0, int seconds=0, int milliseconds=0){
            if(hours > 23 || hours <0 || minutes > 59 || minutes < 0 || 
               seconds > 59 || seconds < 0 || milliseconds > 999 || minutes < 0)
                throw new Exception("Invalid time");

            DateTime = new DateTime(2000,1,1,hours,minutes,seconds,milliseconds);
        }

        public Time(Time outro)
        {
            DateTime = new DateTime(2000,1,1,outro.Hour, outro.Minute, outro.Second, outro.Millisecond);
        }

        public override string ToString()
        {
            return DateTime.ToString("T") + ":" + Millisecond;
        }

        private sealed class DateTimeEqualityComparer : IEqualityComparer<Time>
        {
            public bool Equals(Time x, Time y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.DateTime.Equals(y.DateTime);
            }

            public int GetHashCode(Time obj)
            {
                return obj.DateTime.GetHashCode();
            }
        }

        public static IEqualityComparer<Time> DateTimeComparer { get; } = new DateTimeEqualityComparer();

        public int CompareTo(Time other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return DateTime.CompareTo(other.DateTime);
        }

        public static bool operator <(Time left, Time right)
        {
            return Comparer<Time>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Time left, Time right)
        {
            return Comparer<Time>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Time left, Time right)
        {
            return Comparer<Time>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Time left, Time right)
        {
            return Comparer<Time>.Default.Compare(left, right) >= 0;
        }
    }
}
