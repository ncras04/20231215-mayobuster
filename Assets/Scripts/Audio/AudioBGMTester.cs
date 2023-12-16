using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGMester : MonoBehaviour
{
    [SerializeField]
    private BGMRequestCollection BGM;

    [SerializeField]
    private MusicEvent m_testMusic1;
    [SerializeField]
    private MusicEvent m_testMusic2;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            BGM.Add
                (AudioBGM.Request(m_testMusic1));

        if (Input.GetKeyDown(KeyCode.D))
            BGM.Add
                (AudioBGM.Request(m_testMusic2));
    }
}