using UnityEngine;
using chibi.controller.handler;

namespace chibi.controller.steering.behavior
{
	public class Follow_waypoints_base : Behavior
	{
		public bool loop = false;

		public override Vector3 desire_direction(
			Steering controller, Transform target,
			Steering_properties properties )
		{
			int current_waypoint = properties.current_waypoint;
			var waypoints = properties.waypoints;
			var current_target = waypoints[ current_waypoint ];
			if ( loop )
			{
				if ( Vector3.Distance(
						current_target, controller.transform.position ) < 0.5 )
					properties.current_waypoint += 1;
				if ( properties.current_waypoint > waypoints.Count - 1 )
					properties.current_waypoint = 0;
			}
			else
			{
				if ( properties.current_waypoint < waypoints.Count - 1
					&& Vector3.Distance(
						current_target, controller.transform.position ) < 0.5 )
					properties.current_waypoint += 1;
			}


			var direction = seek( controller, current_target );
			direction.Normalize();
			debug( controller.controller, target, direction );
			return direction.normalized;
		}

		public override float desire_speed(
			Steering controller, Transform target,
			Steering_properties properties )
		{
			return 1f;
		}

		public virtual void debug(
			Controller controller, Transform target, Vector3 direction )
		{
			controller.debug.draw.arrow( direction, seek_color );
		}
	}
}
