using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineManager : MonoBehaviour
{
    public List<int> splineList = new List<int>();

        public IEnumerator ManageSplineList(int splineIndex, float waitTime = 3f)
    {
        splineList.Add(splineIndex);
        yield return new WaitForSeconds(waitTime);
        splineList.Remove(splineIndex);
    }
}
