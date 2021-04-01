using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EpicAsHeckScript : MonoBehaviour
{
    public int NumberOfDeaths;
    [SerializeField] Text TheTextForDeaths;
    [SerializeField] GameObject TheSecretVideo = null;
    [SerializeField] bool ResetUnthinkable = true;

    // On Awake
    private void Awake()
    {
        int GameStatusCount = FindObjectsOfType<EpicAsHeckScript>().Length;
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

    // Start is called before the first frame update
    void Start()
    {
        if (ResetUnthinkable)
        {
            PlayerPrefs.SetInt("Deaths", 0);
        }
        NumberOfDeaths = PlayerPrefs.GetInt("Deaths");
        UpdateLivesText();
    }

    public void IncreaseDeathNum()
    {
        NumberOfDeaths++;
        PlayerPrefs.SetInt("Deaths", NumberOfDeaths);
        if (DoTheUnthinkable())
        {
            TheUnthinkableOption();
        }
        UpdateLivesText();
    }

    public void ResetTheText()
    {
        TheTextForDeaths.text = "";
    }

    public void UpdateLivesText()
    {
        if (TheTextForDeaths != null)
        {
            TheTextForDeaths.text = "Deaths: " + NumberOfDeaths;
        }
    }

    private void TheUnthinkableOption()
    {
        Debug.Log("Losing 3 times? UNTHINKABLE");
        if (TheSecretVideo != null)
        {
            TheSecretVideo.GetComponent<VideoPlayer>().enabled = true;
        }
    }

    public bool DoTheUnthinkable()
    {
        if (NumberOfDeaths == 3 || NumberOfDeaths == 7 || NumberOfDeaths == 42)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
