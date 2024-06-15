namespace PMF.RecurrenceDay
{
	using System;

	/// <inheritdoc />
	/// <summary>
	/// Weekly recurrence
	/// </summary>
	/// <seealso cref="T:PMF.RecurrenceDay.RecurrenceBase" />
	public class WeeklyRecurrence : RecurrenceBase
	{
		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.WeeklyRecurrence" /> class.
		/// </summary>
		public WeeklyRecurrence()
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.WeeklyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		public WeeklyRecurrence(DateTime startDate)
			: base(startDate)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.WeeklyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		public WeeklyRecurrence(DateTime startDate, DateTime endDate)
			: base(startDate, endDate)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.WeeklyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="numberOfOccurrences">The number of occurrences.</param>
		public WeeklyRecurrence(DateTime startDate, int numberOfOccurrences)
			: base(startDate, numberOfOccurrences)
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether [recurs on sunday].
		/// </summary>
		/// <value>
		///   <c>true</c> if [recurs on sunday]; otherwise, <c>false</c>.
		/// </value>
		public bool RecursOnSunday { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [recurs on monday].
		/// </summary>
		/// <value>
		///   <c>true</c> if [recurs on monday]; otherwise, <c>false</c>.
		/// </value>
		public bool RecursOnMonday { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [recurs on tuesday].
		/// </summary>
		/// <value>
		///   <c>true</c> if [recurs on tuesday]; otherwise, <c>false</c>.
		/// </value>
		public bool RecursOnTuesday { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [recurs on wednesday].
		/// </summary>
		/// <value>
		///   <c>true</c> if [recurs on wednesday]; otherwise, <c>false</c>.
		/// </value>
		public bool RecursOnWednesday { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [recurs on thursday].
		/// </summary>
		/// <value>
		///   <c>true</c> if [recurs on thursday]; otherwise, <c>false</c>.
		/// </value>
		public bool RecursOnThursday { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [recurs on friday].
		/// </summary>
		/// <value>
		///   <c>true</c> if [recurs on friday]; otherwise, <c>false</c>.
		/// </value>
		public bool RecursOnFriday { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [recurs on saturday].
		/// </summary>
		/// <value>
		///   <c>true</c> if [recurs on saturday]; otherwise, <c>false</c>.
		/// </value>
		public bool RecursOnSaturday { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets the next date day.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The next date day.</returns>
		protected override DateTime GetNextDateDay(DateTime referenceDate)
		{
			var date = referenceDate.AddDays(1.0).Date;
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Sunday:
					if (this.RecursOnSunday)
					{
						return date;
					}

					break;
				case DayOfWeek.Monday:
					if (this.RecursOnMonday)
					{
						return date;
					}

					break;
				case DayOfWeek.Tuesday:
					if (this.RecursOnTuesday)
					{
						return date;
					}

					break;
				case DayOfWeek.Wednesday:
					if (this.RecursOnWednesday)
					{
						return date;
					}

					break;
				case DayOfWeek.Thursday:
					if (this.RecursOnThursday)
					{
						return date;
					}

					break;
				case DayOfWeek.Friday:
					if (this.RecursOnFriday)
					{
						return date;
					}

					break;
				case DayOfWeek.Saturday:
					if (this.RecursOnSaturday)
					{
						return date;
					}

					return this.GetNextDateDay(date.AddDays((this.RecurrenceInterval - 1) * 7));
			}

			return this.GetNextDateDay(date);
		}
	}
}
