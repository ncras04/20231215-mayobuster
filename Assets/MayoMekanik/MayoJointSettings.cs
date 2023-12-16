using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MayoJointSettings", menuName = "ScriptableObjects/MayoJointSettings", order = 1)]
public class MayoJointSettings : ScriptableObject
{
    [SerializeField] public float xAngleLimit;
    [SerializeField] public float yAngleLimit;
    [SerializeField] public float zAngleLimit;
}
