using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GGC.scene
{
	public class Frog_scene_change: chibi.Chibi_behaviour
	{
		public int scene_index;
		private void OnTriggerEnter( Collider other )
		{
			if ( other.tag == helper.consts.tags.player )
				SceneManager.LoadScene( scene_index );
		}
	}
}
