using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class SoundData : ScriptableObject
{
    public int[,] SheetData
    {
        get
        {
            if (m_sheetData == null)
                MakeData();

            return m_sheetData;
        }
    }

    public AudioClip SongFile => m_songFile;

    [SerializeField]
    private AudioClip m_songFile;

    private int[,] m_sheetData;

    public TextAsset TextData;

    [ContextMenu("Create!!")]
    public void MakeData()
    {
        var datastring = TextData.text;
        var tmpArray = datastring.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(o => o.Trim(new char[] { '\r', '\n' }))
                                    .ToArray();
           
        if (tmpArray.Length % 3 is not 0)
        {
            Debug.LogError("Data was not correctly formatted");
            return;
        }

        var dataSize = (int)(tmpArray.Length / 3);

        if (m_sheetData is null)
            m_sheetData = new int[dataSize, 3];

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
                        m_sheetData[iterator, 0] = value;
                        break;
                    case 1:
                        m_sheetData[iterator, 1] = value;
                        break;
                    case 2:
                        m_sheetData[iterator, 2] = value;
                        break;
                }
            }
        }
    }
}
