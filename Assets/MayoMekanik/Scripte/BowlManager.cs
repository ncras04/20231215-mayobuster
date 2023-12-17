using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BowlManager : MonoBehaviour
{
    [SerializeField] private GameObject BowlPrefab;

    public UnityEvent<Bowl> OnBowlReady;
    public UnityEvent<Bowl> OnBowlFinish;

    private Bowl CurrentBowl;
    private Bowl OldBowl;

    private void Awake()
    {

    }

    private void Start()
    {
        SpawnNewBowl();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) //Just for testing
        {
            SpawnNewBowl();
        }
    }

    public void SpawnNewBowl()
    {
        if (CurrentBowl != null)
        {
            OnBowlFinish.Invoke(CurrentBowl);
            OldBowl = CurrentBowl;
            OldBowl.OnFillBowl.RemoveAllListeners();
            OldBowl.OnBowlReady.RemoveAllListeners();
            OldBowl.MoveAwayBowl();
        }

        CurrentBowl = SpawnBowl();
        CurrentBowl.OnFillBowl.AddListener((Bowl Bowl) => { SpawnNewBowl(); });
        CurrentBowl.OnBowlReady.AddListener((Bowl Bowl) => { OnCurrentBowlReady(); });
    }

    private void OnCurrentBowlReady()
    {
        OnBowlReady?.Invoke(CurrentBowl);
    }

    private Bowl SpawnBowl()
    {
        var NewObj = Instantiate(BowlPrefab, transform.position, transform.rotation);
        return NewObj.GetComponent<Bowl>();
    }
}
