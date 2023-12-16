using UnityEngine;
using Audio;


public class AudioSFXTester : MonoBehaviour
{
    [SerializeField]
    private SoundFXRequestCollection SFX;

    [SerializeField]
    private AudioEvent m_testSound;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SFX.Add
                (AudioSFX.Request(m_testSound, transform));

        if (Input.GetKeyDown(KeyCode.D))
            SFX.Add
                (AudioSFX.Request(m_testSound));

        if (Input.GetKeyDown(KeyCode.S))
            Destroy(gameObject);
    }
}
