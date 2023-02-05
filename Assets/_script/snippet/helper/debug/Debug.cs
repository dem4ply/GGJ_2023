using UnityEngine;

namespace helper
{
	namespace debug
	{
		public class Debug
		{
			protected MonoBehaviour _instance;
			public draw.Draw draw;

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

			public Debug( chibi.Chibi_behaviour instance )
			{
				_instance = instance;
				//draw = new draw.Draw( _instance );
			}

			public void info( object msg )
			{
				info( msg.ToString() );
			}

			public void info( string msg, params object[] list )
			{
				msg = string.Format( msg, list );
			}

			public void log( object msg )
			{
				log( msg.ToString() );
			}

			public void log( string msg, params object[] list )
			{
				info( msg, list );
			}

			public void warning( object msg )
			{
				warning( msg.ToString() );
			}

			public void warning( string msg, params object[] list )
			{
				msg = string.Format( msg, list );
			}

			public void error( object msg )
			{
				error( msg.ToString() );
			}

			public void error( string msg, params object[] list )
			{
				msg = string.Format( msg, list );
			}

			public void pause()
			{
				UnityEngine.Debug.Break();
			}

			protected string full_name
			{
				get { return "prod full name"; }
			}

			protected string type_name
			{
				get { return "prod type name"; }
			}
		}
	}
}
