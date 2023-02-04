using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;
using chibi.controller.steering;
using chibi.controller.steering.behavior;

namespace GGC.controller.player
{

	public class Frog_hat: chibi.controller.Controller
	{
		public int layer = 0;

		public void change_controller_player( GameObject other )
		{
			chibi.animator.Animator_base animator_player = other.GetComponent< chibi.animator.Animator_base >();
			animator_player.change_layer( layer, 1f );
			GameObject.Destroy( this.gameObject );
		}


		private void OnTriggerEnter( Collider other )
		{
			if ( other.tag == helper.consts.tags.player )
			{
				change_controller_player( other.gameObject );
			}
		}

		private void OnCollisionEnter( Collision collision )
		{
			if ( collision.gameObject.tag == helper.consts.tags.player )
			{
				change_controller_player( collision.gameObject );
			}
		}

	}
}
