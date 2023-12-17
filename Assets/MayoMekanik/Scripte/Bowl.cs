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
        AnimationController = GetComponentInChildren<Animator>();
    }

    public void MoveAwayBowl()
    {
        AnimationController.SetBool("MoveAway", true);
    }
}
