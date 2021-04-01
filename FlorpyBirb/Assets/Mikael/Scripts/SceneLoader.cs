using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneLoader")]
public class SceneLoader : MonoBehaviour
{
    [SerializeField] int TheGameScene = 1;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(TheGameScene);
    }
}
