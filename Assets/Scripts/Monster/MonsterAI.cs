using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class MonsterAI : MonoBehaviour {
    public float sightAngle = 120f;
    public Vector3 bornPosition;

    private SphereCollider sphereCollider;
    private CapsuleCollider capsuleCollider;
    private NavMeshAgent agent;
    private GameObject player;
    private bool isInSight;
    private Vector3 playerLastSeenPosition;

    void Awake() {
        sphereCollider = GetComponent<SphereCollider>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    void Start() {
        isInSight = false;
        playerLastSeenPosition = new Vector3(-999, -999, -999);
        agent.stoppingDistance = 2 * (capsuleCollider.radius + 
                                      player.transform.parent.GetComponent<CharacterController>().radius);
    }

    void OnTriggerStay(Collider other) {
        if (isHeroInSight(other)) {
            isInSight = true;
            playerLastSeenPosition = other.transform.position;
        }
    }

    void OnTriggerExit(Collider other) {
        isInSight = false;
    }

    void Update() {
        if (isInSight) {
            agent.SetDestination(playerLastSeenPosition);
        }
    }

    // raycast is not considered yet
    private bool isHeroInSight(Collider other) {
        if (other.gameObject == player) {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, direction);
            return (angle < sightAngle * 0.5f);
        }
        return false;
    }
}
