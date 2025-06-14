namespace Mathc3.Log
{
	public interface ILogService
	{
		void SetPriority( LogPriority priority );
		void Log( string message , LogPriority priority = LogPriority.Main );
		void LogError( string message );
	}

	public enum LogPriority
	{
		Main = 0,
		Level1 = 1,
		Level2 = 2
	}
}

