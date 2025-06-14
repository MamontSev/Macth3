using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

using UnityEngine;

namespace Mathc3.Data.GameItem.Content
{
	[CreateAssetMenu(menuName = "Data/ContentPreset" , fileName = "ContentPreset.asset")]
	public class ContentPreset:ScriptableObject
	{
		public List<ContentItem> ItemList = new();

#if UNITY_EDITOR

		public void CheckState()
		{
			foreach( ContentType type in Enum.GetValues(typeof(ContentType)) )
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
					ItemList.Add(new ContentItem(type));
				}
			}
		}


		[CustomEditor(typeof(ContentPreset))]
		class ContentPresetCustomizer:Editor
		{
			public override void OnInspectorGUI()
			{
				if( GUI.changed )
				{
					EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
				}
				DrawDefaultInspector();
				ContentPreset mt = (ContentPreset)target;
				Undo.RegisterCompleteObjectUndo(mt , "ContentPresetCustomizer");


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


