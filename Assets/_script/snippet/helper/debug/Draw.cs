using UnityEngine;

namespace helper
{
	namespace debug
	{
		namespace draw
		{
			public class Draw
			{
				protected MonoBehaviour _instance;

				public bool debuging
				{
					get {
						var a = _instance as chibi.Chibi_behaviour;
						if ( a )
							return a.debug_mode;
						var b = _instance as chibi.Chibi_behaviour;
						if ( b )
							return b.debug_mode;
						return false;
					}
				}

				public Draw( MonoBehaviour instance )
				{
					_instance = instance;
				}

				public void arrow( Vector3 position, Vector3 direction, float duration=0f )
				{
				}

				public void line( Vector3 position, Vector3 to_position )
				{
				}

				public void arrow(
					Vector3 position, Vector3 direction, Color color,
					float duration=0f )
				{
				}

				public void line(
					Vector3 position, Vector3 to_position, Color color,
					float duration=0f )
				{
				}

				public void arrow( Vector3 direction, Color color, float duration=0f )
				{
				}

				public void line(
					Vector3 to_position, Color color, float duration=0f )
				{
				}

				public void line( Vector3 to_position )
				{
				}

				public void arrow( Vector3 direction, float duration=0f )
				{
				}

				public void arrow_to( Vector3 position, Vector3 to_position )
				{
				}

				public void arrow_to(
					Vector3 position, Vector3 to_position, Color color )
				{
				}

				public void arrow_to( Vector3 to_position )
				{
				}

				public void arrow_to( Vector3 to_position, Color color )
				{
				}

				public void sphere(
					Vector3 position, Color color, float radius, float duration=0f,
					bool depth_test=true )
				{
				}

				public void cube(
					Vector3 position, Vector3 size, Color color,
					float duration=0f )
				{
				}
			}
		}
	}
}
