using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bowl : MonoBehaviour
{
    [SerializeField] private BowlSettings BowlSettings;
    [SerializeField] public UnityEvent<Bowl> OnFillBowl;
    public int ParticleAmount;
    private Animator AnimationController;

    private void Awake()
    {
        AnimationController = GetComponent<Animator>();
    }

    public void MoveAwayBowl()
    {
        AnimationController.SetBool("MoveAway", true);
    }

    public void DestroyBowl() //Is called in Animation Event
    {
        Destroy(gameObject);
    }
}
