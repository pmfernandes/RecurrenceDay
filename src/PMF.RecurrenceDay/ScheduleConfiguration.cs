namespace PMF.RecurrenceDay
{
	using System;
	using Enums;

	/// <summary>
	/// Schedule Configuration
	/// </summary>
	public class ScheduleConfiguration
	{
		/// <summary>
		/// Gets or sets the recurrence calendar.
		/// </summary>
		/// <value>
		/// The recurrence calendar.
		/// </value>
		public RecurrenceBase RecurrenceCalendar { get; set; }

		/// <summary>
		/// Gets or sets the type of the calendar.
		/// </summary>
		/// <value>
		/// The type of the calendar.
		/// </value>
		public RecurrenceCalendarType CalendarType { get; set; }

		/// <summary>
		/// Determines whether [is schedule active].
		/// </summary>
		/// <returns>
		///   <c>true</c> if [is schedule active]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsScheduleActive()
		{
			return this.RecurrenceCalendar != null;
		}

		/// <summary>
		/// Gets the next recurrence date.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The next recurrence date.</returns>
		public DateTime GetNextRecurrenceDate(DateTime referenceDate)
		{
			return this.RecurrenceCalendar.GetNextRecurrenceDate(referenceDate);
		}
	}
}
