using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class setNavigationTarget : MonoBehaviour
{
    // add a field for top down camera
    [SerializeField]
    private Camera topDownCamera;

    // used to register the target location
    [SerializeField]
    private GameObject navTargetObject;

    // initiallizing the routing engine
    private UnityEngine.AI.NavMeshPath path;
    
    // initiallizing the line renderer
    private LineRenderer line;
    private bool lineToggle = false;

    private void Start()
    {
        // used to initailize walkable path
        path = new UnityEngine.AI.NavMeshPath();
        
        // used to initailize line renderer component
        line = transform.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // used to check if the user has registered a touch input
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
            
            // used to turn on or off line to target
            lineToggle = !lineToggle;
        }

        if (lineToggle)
        {
            // used to calculate the shortest path
            UnityEngine.AI.NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas ,path);

            // used to calculate the path length
            line.positionCount = path.corners.Length;

            // used to calculate the path end points
            line.SetPositions(path.corners);

            // used to enable  the line visibility
            line.enabled = true;
        }
    }
}
