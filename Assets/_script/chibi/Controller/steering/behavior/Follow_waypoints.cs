using UnityEngine;
using chibi.controller.handler;

namespace chibi.controller.steering.behavior
{
	[CreateAssetMenu( menuName = "chibi/steering/behavior/follow_waypoints" )]
	public class Follow_waypoints : Follow_waypoints_base
	{
		public override Steering_properties prepare_properties(
			Steering controller, Steering_properties properties,
			Transform target )
		{
			properties = base.prepare_properties(
				controller, properties, target );
			chibi.path.Path_behaviour path = target.GetComponent<
				chibi.path.Path_behaviour>();
			properties.current_waypoint = 0;
			properties.waypoints = path.path.bake_points;

			var handlers = target.GetComponentsInChildren<Handler_behaviour>();
			foreach( var handler in handlers )
				handler.add( controller.controller );
			return properties;
		}
	}
}
