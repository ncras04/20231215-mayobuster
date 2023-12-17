using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MayoEmitter : MonoBehaviour
{
    private GameObject LastMayoObject;
    private IEnumerator StartSpawn;

    public GameObject MayoPrefab;
    public MayoJointSettings MayoSettings;

    [SerializeField] private float MaxX = 10.0f;
    [SerializeField] private float MinX = -10.0f;
    [SerializeField] private float MouseSenibility = 0.05f;
    [SerializeField] private RightKnobTemperature ThermoManager;

    private float ThermoScale;

    void Start()
    {
        StartSpawn = Spawn();
        if (ThermoManager)
        {
            ThermoManager.TemperatureChanged += UpdateThermo;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartSpawn);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(StartSpawn);
            LastMayoObject = null;
        }
    }

    public void MoveTheMayOOO(InputAction.CallbackContext _ctx)
    {
        Vector2 mouseDelta = _ctx.ReadValue<Vector2>();
        float mouseDeltaX = mouseDelta.x * 0.001f * MouseSenibility;

        float NewX = transform.position.x + mouseDeltaX;
        float ClampedX = Mathf.Clamp(NewX, MinX, MaxX);

        transform.position = new Vector3(ClampedX, transform.position.y, transform.position.z);
    }

    private void UpdateThermo(float currentValue, int maxValue)
    {
        ThermoScale = currentValue * 0.01f;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Transform SpawnTrans = transform;

            GameObject Obj = Instantiate(MayoPrefab, SpawnTrans.position, SpawnTrans.rotation);

            if (ThermoManager)
            {
                Obj.transform.localScale = new Vector3(Obj.transform.localScale.x * ThermoScale, Obj.transform.localScale.y, Obj.transform.localScale.z * ThermoScale);
            }

            if (LastMayoObject)
            {
                ConfigurableJoint Joint = LastMayoObject.AddComponent<ConfigurableJoint>();
                SetUpJoint(Obj, Joint);
            }
            LastMayoObject = Obj;
        }
    }

    private void SetUpJoint(GameObject Obj, ConfigurableJoint Joint)
    {
        Joint.xMotion = ConfigurableJointMotion.Limited;
        Joint.yMotion = ConfigurableJointMotion.Limited;
        Joint.zMotion = ConfigurableJointMotion.Limited;

        Joint.angularXMotion = ConfigurableJointMotion.Limited;
        Joint.angularYMotion = ConfigurableJointMotion.Limited;
        Joint.angularZMotion = ConfigurableJointMotion.Limited;

        SoftJointLimit LimitY = new SoftJointLimit();
        LimitY.limit = MayoSettings.yAngleLimit;

        SoftJointLimit LimitX = new SoftJointLimit();
        LimitX.limit = MayoSettings.xAngleLimit;

        SoftJointLimit LimitZ = new SoftJointLimit();
        LimitZ.limit = MayoSettings.zAngleLimit;

        Joint.highAngularXLimit = LimitX;
        Joint.angularYLimit = LimitY;
        Joint.angularZLimit = LimitZ;

        Joint.breakForce = MayoSettings.BreakForce;

        Joint.connectedBody = Obj.GetComponent<Rigidbody>();
    }
}
