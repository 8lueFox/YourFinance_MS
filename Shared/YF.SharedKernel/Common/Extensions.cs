namespace YF.SharedKernel.Common;

public static class Extensions
{
    public static DateTime RoundToMinutes(this DateTime dt)
        => new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute.RoundOff(), 0);

    public static int RoundOff(this int i)
        => ((int)Math.Round(i / 10.0)) * 10;
}
