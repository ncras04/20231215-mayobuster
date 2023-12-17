using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlTrigger : MonoBehaviour
{
    [SerializeField] private BowlSettings BowlSettings;
    private Bowl ParentBowl;

    private void Awake()
    {
        ParentBowl = transform.parent.GetComponent<Bowl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MayoParticle"))
        {
            ParentBowl.ParticleAmount++;
            other.transform.SetParent(transform);
            if (BowlSettings.MayoParticleAmountToFill == ParentBowl.ParticleAmount)
            {
                ParentBowl.OnFillBowl.Invoke(ParentBowl);
            }
        }
    }
}
