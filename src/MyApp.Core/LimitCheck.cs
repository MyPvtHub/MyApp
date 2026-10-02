namespace MyApp.Core;

public enum LimitStatus {Ok, Warning, Breach}

public static class LimitCheck
{
	public static LimitStatus Evaluate(decimal exposure, decimal limit,decimal warningThreshold=0.9m)
	{
		if (limit <=0)
			throw new ArgumentOutOfRangeException(nameof(limit), "Limit must be positive");
		var utilization = Math.Abs(exposure)/limit;
		
		return utilization switch
		{
			> 1m => LimitStatus.Breach,
			_ when utilization >= warningThreshold => LimitStatus.Warning,
			_ => LimitStatus.Ok
		};
	}
}


