namespace PMF.RecurrenceDay
{
	using System;

	/// <inheritdoc />
	/// <summary>
	/// Daily recurrence
	/// </summary>
	/// <seealso cref="T:PMF.RecurrenceDay.RecurrenceBase" />
	public class DailyRecurrence : RecurrenceBase
	{
		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.DailyRecurrence" /> class.
		/// </summary>
		public DailyRecurrence()
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.DailyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		public DailyRecurrence(DateTime startDate)
			: base(startDate)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.DailyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		public DailyRecurrence(DateTime startDate, DateTime endDate)
			: base(startDate, endDate)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.DailyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="numberOfOccurrences">The number of occurrences.</param>
		public DailyRecurrence(DateTime startDate, int numberOfOccurrences)
			: base(startDate, numberOfOccurrences)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Gets the next date day.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The next date day.</returns>
		protected override DateTime GetNextDateDay(DateTime referenceDate)
		{
			return referenceDate.Date.AddDays(this.RecurrenceInterval).Date;
		}
	}
}
