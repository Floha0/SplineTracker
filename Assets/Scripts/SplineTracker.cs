using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineTracker : MonoBehaviour
{
    public float speed;
    public SplineContainer[] spline;
    public GameObject splineManagerObject;
    private SplineManager splineManager;
    private float splineLength;
    private float distancePercentage;
    private int splineIndex;

    void Start()
    {
        spline = FindObjectsOfType<SplineContainer>();
        splineManagerObject = GameObject.Find("SplineManagerObject");
        splineManager = splineManagerObject.GetComponent<SplineManager>();

        RepeatIndex();

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

        if (distancePercentage >= 1f)
        {
            Destroy(this.gameObject);
        }
    }

    private void RepeatIndex()
    {
        splineIndex = Random.Range(0, spline.Length);
        IEnumerator coroutine = splineManager.ManageSplineList(splineIndex, 3f);

        if (splineManager.splineList.Contains(splineIndex))
        {
            RepeatIndex();
        }
        else
        {
            StartCoroutine(coroutine);
        }
    }
}
