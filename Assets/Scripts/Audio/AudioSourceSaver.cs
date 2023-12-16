using Audio;
using UnityEngine;

public class AudioSourceSaver : MonoBehaviour
{
    private void OnDisable()
    {
        AudioSource[] tmp = GetComponentsInChildren<AudioSource>();

        if (tmp is not null)
        {
            for (int i = 0; i < tmp.Length; i++)
            {
                AudioSFXObject obj = tmp[i].GetComponent<AudioSFXObject>();
                obj.Source.Stop();
                tmp[i].transform.SetParent(null);
            }
        }
    }
}
