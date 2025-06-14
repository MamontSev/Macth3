using Cysharp.Threading.Tasks;

namespace Mathc3.Core.Field.Control
{
	public interface IFieldControl
	{
		UniTaskVoid InitOnStart();
		UniTaskVoid ReplayOnWinOrLose();
		UniTaskVoid ShaffleItems();
	}
}