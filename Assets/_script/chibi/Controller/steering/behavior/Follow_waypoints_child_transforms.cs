using UnityEngine;
using chibi.controller.handler;
using System.Collections.Generic;
using System.Linq;

namespace chibi.controller.steering.behavior
{
	[CreateAssetMenu( menuName = "chibi/steering/behavior/follow_waypoints_child_transforms" )]
	public class Follow_waypoints_child_transforms : Follow_waypoints_base
	{
		public override Steering_properties prepare_properties(
			Steering controller, Steering_properties properties,
			Transform target )
		{
			properties = base.prepare_properties(
				controller, properties, target );
			if ( !target )
				Debug.LogError( "no tiene target el steering", controller );
			properties.current_waypoint = 0;
			List<Vector3> waypoints = new List<Vector3>();
			for ( int i = 0; i < target.childCount; ++i )
				waypoints.Add( target.GetChild( i ).position );
			if ( waypoints.Count == 0 )
				Debug.LogError( "no tiene waypoints o child", target );
			properties.waypoints = waypoints;

			var handlers = target.GetComponentsInChildren<Handler_behaviour>();
			foreach( var handler in handlers )
				handler.add( controller.controller );
			return properties;
		}
	}
}
