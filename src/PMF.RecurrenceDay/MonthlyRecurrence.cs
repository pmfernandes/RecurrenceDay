namespace PMF.RecurrenceDay
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Enums;

	/// <inheritdoc />
	/// <summary>
	/// Monthly recurrence
	/// </summary>
	/// <seealso cref="T:PMF.RecurrenceDay.RecurrenceBase" />
	public class MonthlyRecurrence : RecurrenceBase
	{
		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.MonthlyRecurrence" /> class.
		/// </summary>
		public MonthlyRecurrence()
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.MonthlyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		public MonthlyRecurrence(DateTime startDate)
			: base(startDate)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.MonthlyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		public MonthlyRecurrence(DateTime startDate, DateTime endDate)
			: base(startDate, endDate)
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PMF.RecurrenceDay.MonthlyRecurrence" /> class.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="numberOfOccurrences">The number of occurrences.</param>
		public MonthlyRecurrence(DateTime startDate, int numberOfOccurrences)
			: base(startDate, numberOfOccurrences)
		{
		}

		/// <summary>
		/// Gets or sets the type of the monthly recurrence.
		/// </summary>
		/// <value>
		/// The type of the monthly recurrence.
		/// </value>
		public MonthlyRecurrenceType MonthlyRecurrenceType { get; set; }

		/// <summary>
		/// Gets or sets the day number.
		/// </summary>
		/// <value>
		/// The day number.
		/// </value>
		public int DayNumber { get; set; }

		/// <summary>
		/// Gets or sets the ordinal day.
		/// </summary>
		/// <value>
		/// The ordinal day.
		/// </value>
		public OrdinalDay OrdinalDay { get; set; }

		/// <summary>
		/// Gets or sets the type of the day.
		/// </summary>
		/// <value>
		/// The type of the day.
		/// </value>
		public DayType DayType { get; set; }

		/// <inheritdoc />
		/// <summary>
		/// Gets the next date day.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The next date day.</returns>
		/// <exception cref="T:System.Exception">Invalid Monthly Recurrence Type</exception>
		protected override DateTime GetNextDateDay(DateTime referenceDate)
		{
			switch (this.MonthlyRecurrenceType)
			{
				case MonthlyRecurrenceType.SpecificDay:
					return this.GetNextSpecificDay(referenceDate);
				case MonthlyRecurrenceType.ConditionalDay:
					return this.GetNextDayForDayType(referenceDate, this.DayType, false);
				default:
					throw new Exception("Invalid Monthly Recurrence Type");
			}
		}

		/// <summary>
		/// Gets the valid date.
		/// </summary>
		/// <param name="year">The year.</param>
		/// <param name="month">The month.</param>
		/// <param name="day">The day.</param>
		/// <returns>The valid date.</returns>
		private static DateTime GetValidDate(int year, int month, int day)
		{
			var num = DateTime.DaysInMonth(year, month);
			return new DateTime(year, month, day > num ? num : day);
		}

		/// <summary>
		/// Gets the first day of month.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The first day of month.</returns>
		private static DateTime GetFirstDayOfMonth(DateTime referenceDate)
		{
			return new DateTime(referenceDate.Year, referenceDate.Month, 1);
		}

		/// <summary>
		/// Gets the last day of month.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The last day of month.</returns>
		private static DateTime GetLastDayOfMonth(DateTime referenceDate)
		{
			return MonthlyRecurrence.GetFirstDayOfMonth(referenceDate.AddMonths(1)).AddDays(-1.0);
		}

		/// <summary>
		/// Gets the day type list.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <param name="dayType">Type of the day.</param>
		/// <returns>List of day type.</returns>
		/// <exception cref="System.Exception">Invalid Day Type</exception>
		private static List<DateTime> GetDayTypeList(DateTime referenceDate, DayType dayType)
		{
			var list = new List<DateTime>();
			var firstDayOfMonth = MonthlyRecurrence.GetFirstDayOfMonth(referenceDate);
			var lastDayOfMonth = MonthlyRecurrence.GetLastDayOfMonth(referenceDate);
			var dateTime = firstDayOfMonth;
			do
			{
				if (dayType <= DayType.Saturday)
				{
					if (dateTime.DayOfWeek == (DayOfWeek)dayType)
					{
						list.Add(dateTime);
					}
				}
				else
				{
					switch (dayType - 7)
					{
						case DayType.Sunday:
							list.Add(dateTime);
							break;
						case DayType.Monday:
							if (dateTime.DayOfWeek >= DayOfWeek.Monday && dateTime.DayOfWeek <= DayOfWeek.Friday)
							{
								list.Add(dateTime);
								break;
							}

							break;
						case DayType.Tuesday:
							if (dateTime.DayOfWeek == DayOfWeek.Sunday || dateTime.DayOfWeek == DayOfWeek.Saturday)
							{
								list.Add(dateTime);
								break;
							}

							break;
						default:
							throw new Exception("Invalid Day Type");
					}
				}

				dateTime = dateTime.AddDays(1.0);
			}
			while (dateTime <= lastDayOfMonth);
			return list;
		}

		/// <summary>
		/// Gets the next specific day.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <returns>The next specific day.</returns>
		private DateTime GetNextSpecificDay(DateTime referenceDate)
		{
			if (referenceDate.Day < this.DayNumber)
			{
				return MonthlyRecurrence.GetValidDate(referenceDate.Year, referenceDate.Month, this.DayNumber);
			}

			var dateTime = MonthlyRecurrence.GetFirstDayOfMonth(referenceDate).AddMonths(this.RecurrenceInterval);
			return MonthlyRecurrence.GetValidDate(dateTime.Year, dateTime.Month, this.DayNumber);
		}

		/// <summary>
		/// Gets the type of the next day for day.
		/// </summary>
		/// <param name="referenceDate">The reference date.</param>
		/// <param name="dayType">Type of the day.</param>
		/// <param name="acceptReferenceDate">if set to <c>true</c> [accept reference date].</param>
		/// <returns>The next day for day type.</returns>
		/// <exception cref="System.Exception">Ordinal Day is empty.</exception>
		private DateTime GetNextDayForDayType(DateTime referenceDate, DayType dayType, bool acceptReferenceDate)
		{
			if (this.OrdinalDay == OrdinalDay.None)
			{
				throw new Exception("Ordinal Day is empty.");
			}

			var dayTypeList = GetDayTypeList(referenceDate, dayType);
			var dateTime = this.OrdinalDay != OrdinalDay.Last ? dayTypeList[(int)(this.OrdinalDay - 1)] : Enumerable.Last<DateTime>(dayTypeList);
			if (dateTime <= referenceDate && !acceptReferenceDate)
			{
				return this.GetNextDayForDayType(MonthlyRecurrence.GetFirstDayOfMonth(referenceDate).AddMonths(this.RecurrenceInterval), dayType, true);
			}

			return dateTime;
		}
	}
}
