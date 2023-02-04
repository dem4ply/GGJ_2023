using UnityEngine;

namespace chibi.animator
{
	public abstract class Animator_base : chibi.Chibi_behaviour
	{
		#region Var public
		public Animator animator;
		#endregion

		#region funciones protegidas
		protected override void _init_cache()
		{
			if ( !animator )
				animator = GetComponent<Animator>();
			if ( !animator )
			{
				debug.error( "no se encontro el componente animator" );
			}
		}

		public void change_layer( int layer, float weight )
		{
			for ( int i = 0; i < animator.layerCount; ++i )
			{
				animator.SetLayerWeight( i, 0f );
			}
			animator.SetLayerWeight( layer, weight );
		}
		#endregion
	}
}
