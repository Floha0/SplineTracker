using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineTracker : MonoBehaviour
{
    public SplineContainer[] spline;
    public float speed;
    private float splineLength;
    private float distancePercentage;
    private int splineIndex;

    void Start()
    {
        splineIndex = Random.Range(0, spline.Length);
        splineLength = spline[splineIndex].CalculateLength();
    }

    void Update()
    {
        distancePercentage += speed * Time.deltaTime / splineLength;
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = spline[splineIndex].EvaluatePosition(distancePercentage);
        Vector3 nextPosition = spline[splineIndex].EvaluatePosition(distancePercentage + 0.05f);
        Vector3 direction = nextPosition - currentPosition;

        transform.position = currentPosition;
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }
}
