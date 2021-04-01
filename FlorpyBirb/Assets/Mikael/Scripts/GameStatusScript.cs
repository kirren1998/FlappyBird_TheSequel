using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStatusScript : MonoBehaviour
{
    [SerializeField] int Lives = 3;

    private void Awake()
    {
        int GameStatusCount = FindObjectsOfType<GameStatusScript>().Length;
        if (GameStatusCount > 1)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}