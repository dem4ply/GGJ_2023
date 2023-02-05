using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using chibi.controller.steering;
using chibi.controller.steering.behavior;

namespace GGC.controller.player
{
	public enum ai_state
	{
		idle,
		seek,
		patrol,
	}

	public class Frog_AI_controller : chibi.controller.Controller
	{
		public Controller_npc npc;
		public Transform waypoint_patrol;

		protected chibi.controller.steering.Steering steering;
		public float attack_distance = 10f;

		public GameObject player_global;
		public ai_state status;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !npc )
				debug.error( "no esta asignado el npc controller ai" );
			get_sterring();
		}

		private void Update()
		{
			if ( !npc )
				return;
			if ( player_global )
			{
				debug.draw.arrow_to( player_global.transform.position, Color.black );
				float distance = Vector3.Distance( player_global.transform.position, npc.transform.position );
				if ( distance <= attack_distance )
				{
					debug.draw.arrow_to( player_global.transform.position, Color.red );
					motor.Frog_motor motor = ( motor.Frog_motor )npc.motor;
					motor.on_attack();
				}
			}
			if ( player_global == null && status == ai_state.seek )
				set_follow_waypoint();
		}

		protected void get_sterring()
		{
			if ( !npc )
				return;
			steering = npc.GetComponent<Steering>();
			if ( !steering )
				steering = npc.gameObject.AddComponent<Steering>();
		}

		protected void set_follow_waypoint()
		{
			if ( !npc )
				return;
			steering.target = waypoint_patrol;
			steering.controller = npc;
			var behavior = Follow_waypoints_child_transforms.CreateInstance<Follow_waypoints_child_transforms>();
			behavior.loop = true;
			steering.behaviors.Clear();
			steering.behaviors.Add( behavior );
			steering.reload();
			this.status = ai_state.patrol;
		}

		protected void set_seek_player( Transform player )
		{
			if ( !npc )
				return;
			steering.target = player;
			steering.controller = npc;
			var behavior = Seek.CreateInstance<Seek>();
			steering.behaviors.Clear();
			steering.behaviors.Add( behavior );
			steering.reload();
			this.status = ai_state.seek;
		}

		private void OnTriggerEnter( Collider other )
		{
			if ( !npc )
				return;
			if ( other.tag == helper.consts.tags.player )
			{
				set_seek_player( other.gameObject.transform );
				player_global = other.gameObject;
			}
		}

		private void OnTriggerExit( Collider other )
		{
			if ( !npc )
				return;
			if ( other.tag == helper.consts.tags.player )
			{
				set_follow_waypoint();
				player_global = null;
			}
		}

		private void OnCollisionEnter( Collision collision )
		{
			if ( !npc )
				return;
			if ( collision.gameObject.tag == helper.consts.tags.player )
			{
				set_seek_player( collision.transform );
				player_global = collision.gameObject;
			}
		}

		private void OnCollisionExit( Collision collision )
		{
			if ( !npc )
				return;
			if ( collision.gameObject.tag == helper.consts.tags.player )
			{
				set_follow_waypoint();
				player_global = null;
			}
		}
	}
}
