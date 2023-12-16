using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bowl : MonoBehaviour
{
    [SerializeField] private BowlSettings BowlSettings;
    [SerializeField] public UnityEvent<Bowl> OnFillBowl;
    private int ParticleAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MayoParticle"))
        {
            ParticleAmount++;
            other.transform.SetParent(transform);
            if(BowlSettings.MayoParticleAmountToFill == ParticleAmount)
            {
                OnFillBowl.Invoke(this);
            }
        }
    }
}
