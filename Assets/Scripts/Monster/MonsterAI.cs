using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
public class MonsterAI : MonoBehaviour {
    public float sightAngle = 120f;
    public Transform spawnPoint;

    // a point representing nowhere
    private Vector3 playerResetPosition = new Vector3(-999, -999, -999);

    private SphereCollider sphereCollider;
    private CapsuleCollider capsuleCollider;
    private NavMeshAgent agent;

    private GameObject player;
    private Layers layers;

    public bool isInSight;
    private Vector3 playerLastSeenPosition;

    void Awake() {
        sphereCollider = GetComponent<SphereCollider>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
        layers = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Layers>();
    }

    void Start() {
        isInSight = false;
        playerLastSeenPosition = playerResetPosition;
//        agent.stoppingDistance = 2 * (capsuleCollider.radius + 
//                                      player.transform.parent.GetComponent<CharacterController>().radius);
        // precious stoppingDistance should be set in inspector
        // after experiments
    }

    void OnTriggerStay(Collider other) {
        isInSight = (!isInSight) ? isHeroInSight(other) : isInSight;
        playerLastSeenPosition = (isInSight) ? player.transform.position : playerLastSeenPosition;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            isInSight = false;
        }
    }

    void Update() {
        if (playerLastSeenPosition != playerResetPosition) {
            agent.SetDestination(playerLastSeenPosition);
        } else {
            agent.Stop();
        }
    }

    private bool isHeroInSight(Collider other) {
        if (other.gameObject == player) {
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(transform.forward, direction);
            if (angle < sightAngle * 0.5f) {
                LayerMask mask = 1 << layers.player;
                if (Physics.Raycast(transform.position, direction, sphereCollider.radius, mask)) {
                    return true;
                }
            }
        }
        return false;
    }
}
