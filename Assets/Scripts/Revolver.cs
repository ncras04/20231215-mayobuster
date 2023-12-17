using QuickTime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Revolver : MonoBehaviour
{
    [SerializeField] float MinRngRotation = -80.0f;
    [SerializeField] float MaxRngRotation = 0.0f;
    [SerializeField] float ImageDuration = 0.45f;
    [SerializeField] List<GameObject> PowImages;
    private GameObject CurrentImage;
    [SerializeField] AudioSource ShotSound;

    public void Update()
    {
        AQuickTimeEvent Event = FindFirstObjectByType<AQuickTimeEvent>();

        if (Event)
        {
            transform.LookAt(Event.gameObject.transform);
            transform.Rotate(new Vector3(0, 90, 0), Space.Self);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
            //transform.localRotation = Quaternion.Euler(transform.rotation.localRotation + new Vector3(0,0,90));
        }
    }

    public void ShootRevolver(InputAction.CallbackContext _ctx)
    {
        if (CurrentImage is not null) return;
        StartCoroutine(ShowImageRandom());
    }

    private IEnumerator ShowImageRandom()
    {
        int RngIndex = UnityEngine.Random.Range(0, PowImages.Count - 1);
        CurrentImage = PowImages[RngIndex];
        CurrentImage.transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(MinRngRotation, MaxRngRotation));
        CurrentImage.gameObject.SetActive(true);
        ShotSound.time = 0.35f;
        ShotSound.Play();

        yield return new WaitForSeconds(ImageDuration);

        CurrentImage.gameObject.SetActive(false);
        CurrentImage = null;
    }
}
