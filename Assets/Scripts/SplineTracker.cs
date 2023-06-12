using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineTracker : MonoBehaviour
{
    public SplineContainer spline;
    private SplineAnimate fishFollow;
    void Start()
    {
        fishFollow = this.GetComponent<SplineAnimate>();
    }

    void Update()
    {
        
    }
}
