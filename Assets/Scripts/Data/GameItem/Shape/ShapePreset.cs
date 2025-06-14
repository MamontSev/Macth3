using System;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

using UnityEngine;

namespace Mathc3.Data.GameItem.Shape
{
	[CreateAssetMenu(menuName = "Data/ShapePreset" , fileName = "ShapePreset.asset")]
	public class ShapePreset:ScriptableObject
	{
		public List<ShapeItem> ItemList = new();

#if UNITY_EDITOR

		public void CheckState()
		{
			foreach( ShapeType type in Enum.GetValues(typeof(ShapeType)) )
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
					ItemList.Add(new ShapeItem(type));
				}
			}
		}


		[CustomEditor(typeof(ShapePreset))]
		class ShapePresetCustomizer:Editor
		{
			public override void OnInspectorGUI()
			{
				if( GUI.changed )
				{
					EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
				}
				DrawDefaultInspector();
				ShapePreset mt = (ShapePreset)target;
				Undo.RegisterCompleteObjectUndo(mt , "ShapePresetCustomizer");


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


