using UnityEngine;
using System.Collections;

public static class NavMeshAgentExtensions {
	public static bool hasReachedDestination(this NavMeshAgent agent) {
		return (NavMeshPathStatus.PathComplete == agent.pathStatus &&
			    agent.remainingDistance <= agent.stoppingDistance);
	}
}
