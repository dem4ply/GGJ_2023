using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using chibi.controller.steering;
using chibi.controller.steering.behavior;

namespace GGC.controller.player
{
	public class Frog_AI_boss_controller : chibi.controller.Controller
	{
		public Controller_npc npc;
		public chibi.pomodoro.Pomodoro_obj attack_time = new chibi.pomodoro.Pomodoro_obj( 3f );
		public chibi.weapon.gun.Linear_gun gun;

		public GameObject player_global;
		public ai_state status;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !npc )
				debug.error( "no esta asignado el npc controller ai" );
			var linear_gun_obj = npc.transform.Find( "linear_gun" );
			gun = linear_gun_obj.GetComponent<chibi.weapon.gun.Linear_gun>();
		}

		private void Update()
		{
			if ( !npc )
				return;
			if ( player_global )
			{
				attack_time.is_enable = true;
				var aim_to = player_global.transform.Find( "aim_to" );
				gun.aim_to( aim_to );
				if ( attack_time.tick() )
				{
					gun.shot( true );
					attack_time.reset();
				}
			}
			else
				attack_time.reset();
		}

		private void OnTriggerEnter( Collider other )
		{
			if ( !npc )
				return;
			if ( other.tag == helper.consts.tags.player )
			{
				player_global = other.gameObject;
			}
		}

		private void OnTriggerExit( Collider other )
		{
			if ( !npc )
				return;
			if ( other.tag == helper.consts.tags.player )
			{
				player_global = null;
			}
		}

		private void OnCollisionEnter( Collision collision )
		{
			if ( !npc )
				return;
			if ( collision.gameObject.tag == helper.consts.tags.player )
			{
				player_global = collision.gameObject;
			}
		}

		private void OnCollisionExit( Collision collision )
		{
			if ( !npc )
				return;
			if ( collision.gameObject.tag == helper.consts.tags.player )
			{
				player_global = null;
			}
		}
	}
}
