using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using danmaku.controller.player;
using danmaku.controller.npc;
using chibi.damage.motor;

namespace GGC.game_manager
{
	public class Frog_game_checkpoint : chibi.Chibi_behaviour
	{
		public Frog_game_manager manager;
		public chibi.tool.reference.Game_object_reference player_reference;
		public GameObject respawn_point;

		protected override void _init_cache()
		{
			base._init_cache();
			var manager = GameObject.Find( "manager" );
			if ( !manager )
				debug.error( "no se encontro el manager" );
			else
			{
				this.manager = manager.GetComponent<Frog_game_manager>();
			}

			if ( !respawn_point )
			{
				debug.error( "no se asigno el punto de respawn" );
			}

			if ( player_reference.Value )
			{
			}
		}

		private void OnTriggerEnter( Collider other )
		{
			if ( other.tag == helper.consts.tags.player )
			{
				debug.log( "cambiando respawn point a {0}", respawn_point.transform.position );
				manager.start_point = respawn_point.transform;
			}
		}
	}
}
