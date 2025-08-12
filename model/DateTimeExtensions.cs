using System.Globalization;

namespace EventEase.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Formats date as "MMM dd, yyyy" in English culture (e.g., "Aug 15, 2025")
        /// </summary>
        public static string ToEventDateString(this DateTime date)
        {
            return date.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats time as "h:mm tt" in English culture (e.g., "2:30 PM")
        /// </summary>
        public static string ToEventTimeString(this DateTime date)
        {
            return date.ToString("h:mm tt", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats full date as "dddd, MMMM dd, yyyy" in English culture (e.g., "Friday, August 15, 2025")
        /// </summary>
        public static string ToEventFullDateString(this DateTime date)
        {
            return date.ToString("dddd, MMMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats date and time for display in English culture (e.g., "Friday, August 15, 2025 at 2:30 PM")
        /// </summary>
        public static string ToEventDateTimeString(this DateTime date)
        {
            return $"{date.ToEventFullDateString()} at {date.ToEventTimeString()}";
        }

        /// <summary>
        /// Formats session date/time for dashboard display (e.g., "Aug 15, 2025 2:30 PM")
        /// </summary>
        public static string ToSessionTimeString(this DateTime date)
        {
            return date.ToString("MMM dd, yyyy h:mm tt", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Formats TimeSpan as human-readable session duration (e.g., "2d 3h 45m")
        /// </summary>
        public static string ToSessionDurationString(this TimeSpan timeSpan)
        {
            if (timeSpan.TotalDays >= 1)
            {
                return $"{(int)timeSpan.TotalDays}d {timeSpan.Hours}h {timeSpan.Minutes}m";
            }
            else if (timeSpan.TotalHours >= 1)
            {
                return $"{timeSpan.Hours}h {timeSpan.Minutes}m";
            }
            else
            {
                return $"{timeSpan.Minutes}m";
            }
        }

        /// <summary>
        /// Formats member registration date (e.g., "August 2025")
        /// </summary>
        public static string ToMemberSinceString(this DateTime date)
        {
            return date.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
        }
    }
}
