using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using chibi.manager.collision;
using chibi.motor.npc;
using chibi.motor;


namespace GGC.editor.motor.npc
{
	[CustomEditor( typeof( GGC.motor.Frog_motor ) )]
	public class Frog_motor_editor : chibi.editor.motor.npc.Motor_side_scroll_editor
	{
	}
}
