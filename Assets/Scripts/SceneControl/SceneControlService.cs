using System.Collections;

using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mathc3.SceneControl
{
	public class SceneControlService: ISceneControlService
	{
		public async UniTaskVoid LoadScene( string name )
		{
			await SceneManager.LoadSceneAsync(name , LoadSceneMode.Single);
		}
	}
}
