using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using danmaku.controller.player;
using danmaku.controller.npc;
using chibi.damage.motor;
using Cinemachine;

namespace GGC.game_manager
{
	public class Frog_game_manager : chibi.Chibi_behaviour
	{
		[ Header( "joystick" ) ]
		public chibi.joystick.Joystick joystick;
		public GGC.controller.player.Frog_player_controller player_controller;
		public CinemachineVirtualCamera main_camera;
		public GameObject hat;

		[ Header( "player" ) ]
		public int lives;
		public chibi.tool.reference.Game_object_reference player_reference;
		public GameObject player_prefab;
		public Transform start_point;
		public float respawn_time = 3f;

		protected IEnumerator __respawn_player;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !joystick )
				debug.error( "no esta asignado el joytick en el manager" );

			if ( !start_point )
				debug.error( "no esta asignado el punto de inicio del player" );

			if ( !player_controller )
				debug.error( "no esta asignado el player controller" );

			if ( !main_camera )
				debug.error( "no esta asignado la camara" );

			//instance_player();
			if ( player_reference.Value )
			{
				debug.info( "preparando player ya instanciado" );
				add_respawn_events();
			}
		}

		protected void add_respawn_events()
		{
			var hp = player_reference.Value.GetComponent<HP_engine>();
			player_controller.player = player_reference.Value.GetComponent<chibi.controller.npc.Controller_npc>();
			hp.on_died += on_player_died;
			player_controller.enabled = true;
			joystick.enabled = true;
			main_camera.Follow = player_controller.player.transform;
			main_camera.LookAt = player_controller.player.transform;
		}

		protected void instance_player()
		{
			var new_player = helper.instantiate._(
				player_prefab, start_point.position );

			if ( hat )
				helper.instantiate._( hat, start_point.position );

			player_reference.Value = new_player;
			add_respawn_events();
		}

		protected void on_player_died()
		{
			debug.log( "player murio" );
			joystick.enabled = false;
			player_controller.enabled = false;
			__respawn_player = respawn_player();
			StartCoroutine( __respawn_player );
		}

		protected virtual IEnumerator respawn_player()
		{
			yield return new WaitForSeconds( respawn_time );
			instance_player();
		}
	}
}
