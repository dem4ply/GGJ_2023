using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGC.motor
{
	public class Frog_motor : chibi.motor.npc.Motor_side_scroll
	{
		public chibi.damage.motor.HP_engine hp_motor;
		[ Header( "fallback" ) ]
		public float fallback_time = 0.1f;
		public bool is_fallbacking = false;
		public Vector3 fallback_direction = Vector3.zero;
		public float fallback_force = 3;
		protected IEnumerator __fallbacking_coroutine;

		public GameObject explotion_prefab;

		public override Vector3 desire_velocity
		{
			get {
				if ( is_fallbacking )
				{
					return fallback_direction * fallback_force;
				}
				else
					return base.desire_velocity;
			}
		}

		protected virtual IEnumerator fallbacking_coroutine()
		{
			yield return new WaitForSeconds( fallback_time );
			is_fallbacking = false;
			fallback_direction = Vector3.zero;
		}

		public override Vector3 process_motion( ref Vector3 velocity_vector )
		{
			base.process_motion( ref velocity_vector );
			if ( is_fallbacking )
			{
				velocity_vector = fallback_direction * fallback_force;
				debug.draw.arrow( velocity_vector, Color.yellow, duration:10 );
				_proccess_gravity( ref velocity_vector );
				debug.draw.arrow( velocity_vector, Color.green, duration:10 );
				fallback_direction = velocity_vector.normalized;
			}
			return velocity_vector;
		}

		protected override void _init_cache()
		{
			base._init_cache();

			hp_motor = GetComponent< chibi.damage.motor.HP_engine >();
			if ( !hp_motor )
				debug.error( "no se encontro un hp_engine" );

			hp_motor.on_died += on_died;
			hp_motor.on_take_damage += on_take_damage;
			if ( !explotion_prefab )
				debug.warning( "no hay un prefab de explocion" );
		}

		protected override void _dispose_cache()
		{
			base._dispose_cache();
			hp_motor.on_died -= on_died;
			hp_motor.on_take_damage -= on_take_damage;
		}

		public virtual void on_died()
		{
			if ( explotion_prefab )
				helper.instantiate._( explotion_prefab, transform.position );
			recycle();
		}

		public virtual void on_take_damage( int amount, Vector3 fall_back_direction )
		{
			debug.log( "recivio danno de {0} se empuja a la direcion {1}", amount, fall_back_direction );
			fallback_direction = fall_back_direction.normalized;
			is_fallbacking = true;
			__fallbacking_coroutine = fallbacking_coroutine();
			StartCoroutine( __fallbacking_coroutine );
		}
	}
}
