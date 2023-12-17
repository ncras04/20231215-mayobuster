using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlReadyer : MonoBehaviour
{
    public void BowlReady()
    {
        Bowl Bowl = transform.parent.GetComponent<Bowl>();
        Bowl.OnBowlReady?.Invoke(Bowl);
    }
}
