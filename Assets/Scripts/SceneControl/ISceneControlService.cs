using Cysharp.Threading.Tasks;

namespace Mathc3.SceneControl
{
	public interface ISceneControlService
	{
		UniTaskVoid LoadScene( string name );
	}
}										 
															  