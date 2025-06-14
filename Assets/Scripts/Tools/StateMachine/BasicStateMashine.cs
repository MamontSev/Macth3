using System;
using System.Collections.Generic;

namespace Manmont.Tools.StateMashine
{
	public abstract class BasicStateMashine<T> where T: IState
	{
		private readonly Dictionary<Type , IState> _stateDict = new();

		private IState _currState;
		public IState CurrState => _currState;
	
		public void Register<Tstate>( T state ) where Tstate : T
		{
			_stateDict.Add(typeof(Tstate) ,state);
		}

		public void Enter<Tstate>() where Tstate : T
		{
			ExitCurr();
			_currState = _stateDict[typeof(Tstate)];
			EnterCurr();
		}

		private void ExitCurr()
		{
			if( _currState is IExitState exitState )
			{
				exitState.Exit();
			}
		}
		private void EnterCurr()
		{
			if( _currState is IEnterState enterState )
			{
				enterState.Enter();
			}
		}

		public void Update()
		{
			if( _currState is IUpdateState updateState )
			{
				updateState.Update();
			}
		}
	}
}
