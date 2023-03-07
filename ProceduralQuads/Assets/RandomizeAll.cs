using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class that will easily grab all randomizable objects and randomize them
/// This is almost the same as death for the player
/// </summary>
public class RandomizeAll : MonoBehaviour
{
    public void Randomize()
    {
        RandomizePositionScale[] rs = FindObjectsOfType<RandomizePositionScale>();
        for (int i = 0; i < rs.Length; i++)
        {
            rs[i].Randomize();
            if (rs[i].GetComponent<RandomizeColor>())
                rs[i].GetComponent<RandomizeColor>().Randomize();
        }
    }
}
