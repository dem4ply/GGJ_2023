using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;
using UnityEngine.InputSystem;

namespace GGC.controller.player
{
	enum ai_state
	{
		idle
	}

	public class Frog_AI_controller : chibi.controller.Controller
	{
		public Controller_npc npc;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !npc )
				debug.error( "no esta asignado el npc controller ai" );
		}
	}
}
