namespace WebApi.Domain.Const
{
    public static class TimeConst
    {
        public static DateTime ThreeMonthsAgo { get => Now.AddMonths(-3); }
        public static DateTime Now { get => DateTime.Now; }
        public static int CurrentYear { get => Now.Year; }
        public static int CurrentMonth { get => Now.Month; }
        public static int CurrentDay { get => Now.Day; }
        public static DayOfWeek CurrentDayOfWeek { get => Now.DayOfWeek; }
        public static DateTime UtcNow { get => DateTime.UtcNow; }
    }
}
