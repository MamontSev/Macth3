using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;

namespace Mathc3.Editor
{
	[InitializeOnLoad]
	public class BootstrapSceneLoader:EditorWindow
	{

		private const string _bootstrapScenePath = "Assets/Scenes/Bootstrap.unity";

		static BootstrapSceneLoader()
		{
			EditorApplication.playModeStateChanged += LoadDefaultScene;
		}

		static void LoadDefaultScene( PlayModeStateChange state )
		{
			if( state == PlayModeStateChange.ExitingEditMode )
			{
				if( EditorSceneManager.GetActiveScene().path != _bootstrapScenePath )
				{

					PlayerPrefs.SetString("dsl_lastPath" , EditorSceneManager.GetActiveScene().path);
					PlayerPrefs.Save();

					EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();

					EditorApplication.delayCall += () =>
					{
						EditorSceneManager.OpenScene(_bootstrapScenePath);
						EditorApplication.isPlaying = true;
					};

					EditorApplication.isPlaying = false;
				}
			}

			if( state == PlayModeStateChange.EnteredEditMode )
			{
				if( PlayerPrefs.HasKey("dsl_lastPath") )
				{
					EditorSceneManager.OpenScene(PlayerPrefs.GetString("dsl_lastPath"));
				}
			}
		}
	}
}
