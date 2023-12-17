using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MayoJointSettings", menuName = "ScriptableObjects/MayoJointSettings", order = 1)]
public class MayoJointSettings : ScriptableObject
{
    public float xAngleLimit;
    public float yAngleLimit;
    public float zAngleLimit;
    public float BreakForce = 5.0f;
}
