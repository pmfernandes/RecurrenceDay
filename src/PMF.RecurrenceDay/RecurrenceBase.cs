namespace PMF.RecurrenceDay
{
	using System;
	using Enums;

	/// <summary>
	/// Recurrence base
	/// </summary>
	public abstract class RecurrenceBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RecurrenceBase"/> class.
		/// </summary>
		protected RecurrenceBase()
		{
			this.StartDate = DateTime.Now;
			this.EndDate = new DateTime?();
			this.EndDateType = EndDateType.NoEndDate;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RecurrenceBase"/> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		protected RecurrenceBase(DateTime startDate)
		{
			this.StartDate = startDate;
			this.EndDate = new DateTime?();
			this.EndDateType = EndDateType.NoEndDate;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RecurrenceBase"/> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		protected RecurrenceBase(DateTime startDate, DateTime endDate)
		{
			this.StartDate = startDate;
			this.EndDate = new DateTime?(endDate);
			this.EndDateType = EndDateType.SpecificDate;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RecurrenceBase"/> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="numberOfOccurrences">The number of occurrences.</param>
		protected RecurrenceBase(DateTime startDate, int numberOfOccurrences)
		{
			this.StartDate = startDate;
			this.EndDate = new DateTime?();
			this.NumberOfOccurrences = numberOfOccurrences;
			this.EndDateType = EndDateType.NumberOfOccurrences;
		}

		/// <summary>
		/// Gets or sets the start date.
		/// </summary>
		/// <value>
		/// The start date.
		/// </value>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		/// <value>
		/// The end date.
		/// </value>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Gets or sets the number of occurrences.
		/// </summary>
		/// <value>
		/// The number of occurrences.
		/// </value>
		public int NumberOfOccurrences { get; set; }

		/// <summary>
		/// Gets or sets the end type of the date.
		/// </summary>
		/// <value>
		/// The end type of the date.
		/// </value>
		public EndDateType EndDateType { get; set; }

		/// <summary>
		/// Gets or sets the recurrence interval.
		/// </summary>
		/// <value>
		/// The recurrence interval.
		/// </value>
		public int RecurrenceInterval { get; set; }

		/// <summary>
		/// Gets or sets the type of the daily recurrence.
		/// </summary>
		/// <value>
		/// The type of the daily recurrence.
		/// </value>
		public DailyRecurrenceType DailyRecurrenceType { get; set; }

		/// <summary>
		/// Gets or sets the daily recurrence start time.
		/// </summary>
		/// <value>
		/// The daily recurrence start time.
		/// </value>
		public TimeSpan DailyRecurrenceStartTime { get; set; }

		/// <summary>
		/// Gets or sets the daily recurrence end time.
		/// </summary>
		/// <value>
		/// The daily recurrence end time.
		/// </value>
		public TimeSpan DailyRecurrenceEndTime { get; set; }

		/// <summary>
		/// Gets or sets the daily recurrence interval.
		/// </summary>
		/// <value>
		/// The daily recurrence interval.
		/// </value>
		public int DailyRecurrenceInterval { get; set; }

		/// <summary>
		/// Gets the next recurrence date.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The next recurrence date.</returns>
		public DateTime GetNextRecurrenceDate(DateTime referenceDate)
		{
			var nextDateDay = this.GetNextDateDay(referenceDate);

			if (this.DailyRecurrenceType == DailyRecurrenceType.Once)
			{
				return nextDateDay.Add(this.DailyRecurrenceStartTime);
			}

			var dateTime = referenceDate.AddMinutes(this.DailyRecurrenceInterval * (int)this.DailyRecurrenceType);

			if (dateTime.Day != referenceDate.Day)
			{
				return nextDateDay.Add(this.DailyRecurrenceStartTime);
			}

			var timeSpan = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);

			if (timeSpan > this.DailyRecurrenceEndTime)
			{
				dateTime = nextDateDay.Add(this.DailyRecurrenceStartTime);
			}

			if (timeSpan < this.DailyRecurrenceStartTime)
			{
				dateTime = referenceDate.Date.Add(this.DailyRecurrenceStartTime);
			}

			return dateTime;
		}

		/// <summary>
		/// Gets the next date day.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The next day.</returns>
		protected abstract DateTime GetNextDateDay(DateTime referenceDate);
	}
}
