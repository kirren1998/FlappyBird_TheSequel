using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneLoader")]
public class SceneLoader : MonoBehaviour
{
    [SerializeField] int TheGameScene = 1;

    // Upon load
    private void Start()
    {
        if (FindObjectOfType<EpicAsHeckScript>())
        {
            FindObjectOfType<EpicAsHeckScript>().ResetTheText();
        }
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(TheGameScene);
    }
}
