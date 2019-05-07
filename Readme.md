# Recurrency Day PMFernandes Implementation 

* * *

## Community

This is a personal project to implement Recurrency Day.

## Example

Function to return my ScheduleConfiguration
```csharp
private ScheduleConfiguration GetScheduleConfiguration()
{
	var interval = 10
	var dailyRecurrence = new DailyRecurrence
	{
		DailyRecurrenceType = DailyRecurrenceType.Minutely,
		DailyRecurrenceStartTime = TimeSpan.Parse("00:00:00"),
		DailyRecurrenceEndTime = TimeSpan.Parse("23:59:59"),
		DailyRecurrenceInterval = interval,
		RecurrenceInterval = interval
	};

	var scheduleConfiguration = new ScheduleConfiguration
	{
		CalendarType = RecurrenceCalendarType.DailyRecurrence,
		RecurrenceCalendar = dailyRecurrence
	};

	return scheduleConfiguration;
}
```

How to check if it's time to be executed
```csharp
var lastExecutionDate = DateTime.Now.AddHours(-1);
if (this.GetScheduleConfiguration().GetNextRecurrenceDate(lastExecutionDate) < DateTime.Now)
{
	Console.Write("This is executed");
}
```

## Contribute

There are many ways to contribute.

Feel free to contact me.

## License

This project uses the [MIT License](LICENSE).
