using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BowlManager : MonoBehaviour
{
    [SerializeField] private GameObject SpawnLocation;
    [SerializeField] private GameObject PlaylLocation;
    [SerializeField] private GameObject RemovelLocation;
    [SerializeField] private GameObject BowlPrefab;
    [SerializeField] private BowlSettings BowlSettings;

    public UnityEvent<Bowl> NewBowlReady;

    private Bowl CurrentBowl;
    private Bowl OldBowl;
    private IEnumerator MoveToPlayLocation;
    private IEnumerator MoveToRemoveLocation;

    private void Awake()
    {
        MoveToPlayLocation = MoveToPlay();
        MoveToRemoveLocation = MoveToRemove();
    }

    private void Start()
    {
        SpawnNewBowl();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SpawnNewBowl();
        }   
    }

    public void SpawnNewBowl()
    {
        if(CurrentBowl != null)
        {
            OldBowl = CurrentBowl;
            CurrentBowl = null;
            StartCoroutine(MoveToRemoveLocation);
        }

        CurrentBowl = SpawnBowl();

        StartCoroutine(MoveToPlayLocation);
    }

    private void DestroyOldBowl()
    {
        Destroy(OldBowl.gameObject);
    }

    private Bowl SpawnBowl()
    {
        var NewObj = Instantiate(BowlPrefab, SpawnLocation.transform.position, SpawnLocation.transform.rotation);
        return NewObj.GetComponent<Bowl>();
    }

    private IEnumerator MoveToPlay()
    {
        if(!CurrentBowl) yield break;
        
        while ((CurrentBowl.transform.position - PlaylLocation.transform.position).magnitude > 0.01f)
        {
            Vector3 Loaction = Vector3.Lerp(CurrentBowl.transform.position, PlaylLocation.transform.position, BowlSettings.BowlMoveInSpeed);
            CurrentBowl.transform.position = Loaction;
            yield return new WaitForEndOfFrame();
        }

        NewBowlReady.Invoke(CurrentBowl);
        yield break;
    }

    private IEnumerator MoveToRemove()
    {
        if (!OldBowl) yield break;

        while ((OldBowl.transform.position - RemovelLocation.transform.position).magnitude > 0.01f)
        {
            Vector3 Loaction = Vector3.Lerp(OldBowl.transform.position, RemovelLocation.transform.position, BowlSettings.BowlMoveOutSpeed);
            OldBowl.transform.position = Loaction;
            yield return new WaitForEndOfFrame();
        }

        DestroyOldBowl();
        yield break;
    }
}
