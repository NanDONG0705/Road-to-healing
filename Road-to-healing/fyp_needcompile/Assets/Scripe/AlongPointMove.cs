using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AlongPointMove : MonoBehaviour
{
    public VRChange change;

    public float v; //km/h
    private List<Vector3> path=new List<Vector3>();

    public Transform point0;
    public Transform point1;
    public Transform point2;
    public Transform point3;

    private float totalLength; //路的总长度
    private float currentS; //当前已经走过的路程

    private int index=0;
    public LineRenderer lineRenderer;
    private float startTime;



    private void OnEnable()
    {
        currentS = 0;
        totalLength = 0;
        index = 0;
        //Debug.Log("test"+currentS);
        path = BezierUtility.BezierIntepolate4List(point0.position, point1.position, point2.position, point3.position, 50);


        lineRenderer.positionCount = path.Count;
        lineRenderer.SetPositions(path.ToArray());

        for (int i = 1; i < path.Count; i++)
        {
            totalLength += (path[i] - path[i - 1]).magnitude;
        }

        startTime = Time.time;
    }

    




    Vector3 dir;
    Vector3 pos;
    // Update is called once per frame
    void Update()
    {
        float s = (v * 10 / 36) * (Time.time - startTime); //得到应该要移动的位置
        //Debug.Log(s);

        if (currentS < totalLength)
        {
            for (int i = index; i < path.Count-1; i++)
            {
                currentS += (path[i + 1] - path[i]).magnitude;//计算下一个点的路程

                if (currentS > s)
                {
                    index = i;
                    currentS -= (path[i + 1] - path[i]).magnitude;
                    dir = (path[i + 1] - path[i]).normalized;
                    pos = path[i] + dir * (s - currentS);
                    break;

                }
            }
            transform.position = pos;

           
        }
        else
        {
            change.ScripeSwitch();
            this.enabled = false;

        }

    }


}
