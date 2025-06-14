using System;
using System.Collections.Generic;

using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;

namespace Mathc3.Data.GameItem.Frame
{
	[CreateAssetMenu(menuName = "Data/FramePreset" , fileName = "FramePreset.asset")]
	public class FramePreset:ScriptableObject
	{
		public List<FrameItem> ItemList = new();

#if UNITY_EDITOR

		public void CheckState()
		{
			foreach( FrameType type in Enum.GetValues(typeof(FrameType)) )
			{
				bool contain = false;
				foreach( var item in ItemList )
				{
					if( item.SelfType == type )
					{
						contain = true;
						break;
					}
				}
				if( contain == false )
				{
					ItemList.Add(new FrameItem(type));
				}
			}
		}


		[CustomEditor(typeof(FramePreset))]
		class FramePresetCustomizer:Editor
		{
			public override void OnInspectorGUI()
			{
				if( GUI.changed )
				{
					EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
				}
				DrawDefaultInspector();
				FramePreset mt = (FramePreset)target;
				Undo.RegisterCompleteObjectUndo(mt , "FramePresetCustomizer");


				if( GUILayout.Button("CheckState" , GUILayout.ExpandWidth(false)) )
				{
					mt.CheckState();
				}

				if( GUI.changed )
				{
					EditorUtility.SetDirty(this);
					EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
				}
			}

		}


#endif
	}
}


