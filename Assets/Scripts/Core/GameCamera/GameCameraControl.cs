using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Mathc3.Core.GameCamera
{
	public class GameCameraControl:MonoBehaviour, IGameCameraControl
	{
		[SerializeField]
		private Camera _camera3d;
		public Camera Camera3d => _camera3d;
	}
}
