using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace DSSRecovery
{
	// Tooling (2026-09-27): lists waypoint segments of (near) zero length in every scene of the build. WaypointLogic divides
	// by the segment length (GetWallOffsetForPoint / GetWallDistanceAtPoint): a zero-length segment gives NaN positions.
	// Run with -executeMethod DSSRecovery.WaypointCheck.Run
	public static class WaypointCheck
	{
		public static void Run()
		{
			var sb = new StringBuilder();
			foreach (var s in EditorBuildSettings.scenes.Where(x => x.enabled))
			{
				var scene = EditorSceneManager.OpenScene(s.path, OpenSceneMode.Single);
				var wps = Object.FindObjectsByType<WaypointLogic>(FindObjectsInactive.Include, FindObjectsSortMode.None);
				int zero = 0;
				foreach (var w in wps)
				{
					foreach (var o in new[] { w.forwardPoint, w.backwardPoint })
					{
						if (o == null) continue;
						float d = (o.transform.position - w.transform.position).magnitude;
						if (d < 0.05f)
						{
							zero++;
							sb.AppendLine(string.Format("{0}: '{1}' -> '{2}' length {3} at {4}", scene.name, w.name, o.name, d, w.transform.position));
						}
					}
				}
				sb.AppendLine(string.Format("== {0}: {1} waypoints, {2} zero-length links", scene.name, wps.Length, zero));
			}
			File.WriteAllText("../logs/waypointcheck.txt", sb.ToString());
		}
	}
}
