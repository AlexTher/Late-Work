using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : PathNode
{
    PathNode end;

    public bool debugLines = true;

    public float TotalDistance()
    {
        PathNode rover = this;
        float totalD = 0f;
        while (rover.next != null)
        {
            totalD += (rover.next.transform.position - rover.transform.position).magnitude;

            rover = rover.next;
        }
        return totalD;
    }

    private void Start()
    {
        if (!IsSafe())
        {
            print("Infinite loop in " + name + ", killing path.");
            next = null;
            end = null;
            enabled = false;
        }
    }

    private void Update()
    {
        print(TotalDistance());
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
        while (rover.next != end && safetyCounter < 999)
        {
            safetyCounter++;
            rover = rover.next;
        }
        return safetyCounter < 999;
    }
}
