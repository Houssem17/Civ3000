using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V_AnimationSystem;

/*
 * Character moves between waypoints
 * */
public class CharacterWaypointsHandler : MonoBehaviour {
        
    private const float speed = 30f;

    [SerializeField] private List<Vector3> waypointList;
    private int waypointIndex;

    [SerializeField] private string idleAnimation = "dMarine_Idle";
    [SerializeField] private string walkAnimation = "dMarine_Walk";

    [SerializeField] private float idleFrameRate = 1f;
    [SerializeField] private float walkFrameRate = 1f;

    private V_UnitSkeleton unitSkeleton;
    private V_UnitAnimation unitAnimation;
    private AnimatedWalker animatedWalker;


    private void Start() {
        Transform bodyTransform = transform.Find("Body");
        unitSkeleton = new V_UnitSkeleton(1f, bodyTransform.TransformPoint, (Mesh mesh) => bodyTransform.GetComponent<MeshFilter>().mesh = mesh);
        unitAnimation = new V_UnitAnimation(unitSkeleton);
        animatedWalker = new AnimatedWalker(unitAnimation, UnitAnimType.GetUnitAnimType(idleAnimation), UnitAnimType.GetUnitAnimType(walkAnimation), idleFrameRate, walkFrameRate);
    }
    private void Update() {
        HandleMovement();
        unitSkeleton.Update(Time.deltaTime);
    }
    private void HandleMovement() {
        Vector3 waypoint = waypointList[waypointIndex];

        Vector3 waypointDir = (waypoint - transform.position).normalized;

        float distanceBefore = Vector3.Distance(transform.position, waypoint);
        animatedWalker.SetMoveVector(waypointDir);
        transform.position = transform.position + waypointDir * speed * Time.deltaTime;
        float distanceAfter = Vector3.Distance(transform.position, waypoint);

        if (distanceBefore <= distanceAfter) {
            // Go to next waypoint
            waypointIndex = (waypointIndex + 1) % waypointList.Count;
        }
    }
}
