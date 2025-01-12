namespace WebApi.Domain.Const
{
    public static class TimeConst
    {
        public static DateTime ThreeMonthsAgo { get => DateTime.Now.AddMonths(-3); }
        public static DateTime Now { get => DateTime.Now; }
        public static int CurrentYear { get => DateTime.Now.Year; }
        public static int CurrentMonth { get => DateTime.Now.Month; }
        public static int CurrentDay { get => DateTime.Now.Day; }
        public static DayOfWeek CurrentDayOfWeek { get => DateTime.Now.DayOfWeek; }
        public static DateTime UtcNow { get => DateTime.UtcNow; }
    }
}
