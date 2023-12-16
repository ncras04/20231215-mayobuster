using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoEmitter : MonoBehaviour
{
    private GameObject LastMayoObject;
    private IEnumerator StartSpawn;

    [SerializeField] public GameObject MayoPrefab;
    [SerializeField] public MayoJointSettings MayoSettings;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn = Spawn();
    }

    // Update is called once per frame
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

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Transform SpawnTrans = transform;

            if (LastMayoObject)
            {
                Vector3 RawBounds = LastMayoObject.GetComponent<BoxCollider>().size;
                Vector3 Scale = LastMayoObject.transform.localScale;
                Vector3 ScaledBounds = new Vector3(RawBounds.x * Scale.x, RawBounds.y * Scale.y, RawBounds.z * Scale.z);
                ScaledBounds = new Vector3(0, ScaledBounds.y * 2.0f, 0);
               //SpawnTrans = LastMayoObject.transform;
               //SpawnTrans.position += LastMayoObject.transform.up * ScaledBounds.y;
                Debug.Log("Up:" + LastMayoObject.transform.up * ScaledBounds.y + " | Bounds: " + ScaledBounds + " | Raw: " + RawBounds);
            }

            GameObject Obj = Instantiate(MayoPrefab, SpawnTrans.position, SpawnTrans.rotation);
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

        Joint.connectedBody = Obj.GetComponent<Rigidbody>();

        //Debug.Log(Joint.connectedAnchor);
    }
}
