using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings settings;
    private void Awake()
    {
        if (settings == null)
        {
            settings = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }
    public void ChangeDifficulty(Difficulty diff)
    {
        difficulty = diff;
    }
    public Difficulty difficulty = Difficulty.easy;
    public enum Difficulty
    {
        nulll,
        easy,
        medium,
        hard,
        impossibru,
    }
}
