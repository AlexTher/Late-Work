using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : PathNode
{
    PathNode end;

    public bool debugLines = true;

    public float totalDistance { get; private set; }

    public EdgeCollider2D pathCollider;

    //use this function to (re)calculate the distances along the path
    public float CalculateDistances()
    {
        PathNode rover = this;
        float totalD = 0f;
        while (rover.next != null)
        {
            totalD += (rover.next.transform.position - rover.transform.position).magnitude;
            rover.distBetween = NodeDistance(rover, rover.next);
            rover = rover.next;
        }

        totalDistance = totalD;
        return totalD;
    }
    //dumb version of the pathing that traverses the nodes everytime, replace with one that references the current node
    public Vector2 PosOnPath(float dist)
    {
        PathNode rover = this;
        float travelDist = 0f;
        while (rover.next != null)
        {
            if (rover.distBetween + travelDist >= dist)
            {
                break;
            }
            travelDist += rover.distBetween;
            rover = rover.next;
        }
        return NodeLerp(rover, (dist - travelDist) / rover.distBetween);

    }

    //much better and sexier position function
    public Vector2 PosOnPath(float dist, ref float nodeDist, ref PathNode node)
    {
        if (nodeDist >= node.distBetween && node.next != null)
        {
            //assign new parent node
            nodeDist -= node.distBetween;
            node = node.next;
        }
        return NodeLerp(node, nodeDist / node.distBetween);
    }

    public Vector2 NodeLerp(PathNode node, float t)
    {
        if (node.next != null)
        {
            return Vector2.Lerp(node.transform.position, node.next.transform.position, t);
        } else
        {
            return node.transform.position;
        }
    }

    private void Start()
    {
        pathCollider.offset = -transform.position;
        if (!IsSafe())
        {
            print("Infinite loop in " + name + ", killing path.");
            next = null;
            end = null;
            enabled = false;
        }
        CalculateDistances();
    }

    private void OnDrawGizmos()
    {
        if (debugLines)
        {
            PathNode rover = this;
            while (rover.next != null)
            {
                DrawDebugLine(rover.transform.position, rover.next.transform.position);
                rover = rover.next;
            }
        }
    }

    private void Update()
    {

    }

    public static void DrawDebugLine(Vector3 start, Vector3 end)
    {
        Debug.DrawLine(start, end, Color.green);
        float angle = Mathf.Atan2(end.x - start.x, end.y - start.y);
        float lAngle = angle + (3f / 4) * Mathf.PI;
        float rAngle = angle - (7f / 4) * Mathf.PI;

        Debug.DrawLine(end,end + new Vector3(Mathf.Cos(-lAngle), Mathf.Sin(-lAngle)), Color.green);
        Debug.DrawLine(end,end + new Vector3(Mathf.Cos(-rAngle), Mathf.Sin(-rAngle)), Color.green);
    }

    //checks for safety
    public bool IsSafe()
    {
        int safetyCounter = 0;
        PathNode rover = this;
        List<Vector2> points = new();
        while (rover.next != end && safetyCounter < 999)
        {
            safetyCounter++;
            points.Add(rover.transform.position);
            rover = rover.next;
        }
        points.Add(rover.transform.position);
        pathCollider.SetPoints(points);
        return safetyCounter < 999;
    }

    private float NodeDistance(PathNode start, PathNode end)
    {
        return (end.transform.position - start.transform.position).magnitude;
    }
}
