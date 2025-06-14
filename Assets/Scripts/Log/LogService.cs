using UnityEngine;

namespace Mathc3.Log
{
	public class LogService:  ILogService
	{
		private LogPriority logPriority = LogPriority.Main;
		public void SetPriority( LogPriority priority )
		{
			logPriority = priority;
		}
		public void Log( string message , LogPriority priority = LogPriority.Main )
		{
			if( priority < logPriority ) 
			{
				return;
			}
			Debug.Log(message);
		}

		public void LogError( string message )
		{
			Debug.LogError(message);
		}

		
	}
}
