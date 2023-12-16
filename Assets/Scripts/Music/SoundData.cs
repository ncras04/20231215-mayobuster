using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class SoundData : ScriptableObject
{
    public AudioClip m_songFile;

    private int[,] pauseData;
    public TextAsset soundData;

    [ContextMenu("Create!!")]
    public void MakeData()
    {
        var datastring = soundData.text;
        var tmpArray = datastring.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(o => o.Trim(new char[] { '\r', '\n' }))
                                    .ToArray();
           
        if (tmpArray.Length % 3 is not 0)
        {
            Debug.LogError("Data was not correctly formatted");
            return;
        }

        var dataSize = (int)(tmpArray.Length / 3);

        if (pauseData is null)
            pauseData = new int[dataSize, 3];

        int value;
        int iterator = 0;

        for (int i = 0; i < tmpArray.Length; i++)
        {
            if (i % 3 == 0)
                iterator = i / 3;

            if (int.TryParse(tmpArray[i], out value))
            {
                switch (i % 3)
                {
                    case 0:
                        pauseData[iterator, 0] = value;
                        break;
                    case 1:
                        pauseData[iterator, 1] = value;
                        break;
                    case 2:
                        pauseData[iterator, 2] = value;
                        break;
                }
            }
        }
    }
}
