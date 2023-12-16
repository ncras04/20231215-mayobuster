using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BowlSettings", menuName = "ScriptableObjects/BowlSettings", order = 1)]
public class BowlSettings : ScriptableObject
{
    [SerializeField] public int MayoParticleAmountToFill = 30;
    [SerializeField] public float BowlMoveInSpeed = 0.1f;
    [SerializeField] public float BowlMoveOutSpeed = 0.1f;
}
