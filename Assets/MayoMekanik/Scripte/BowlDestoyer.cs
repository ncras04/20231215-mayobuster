using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlDestoyer : MonoBehaviour
{
    public void DestroyBowl() //Is called in Animation Event
    {
        Destroy(transform.parent.gameObject);
    }
}
