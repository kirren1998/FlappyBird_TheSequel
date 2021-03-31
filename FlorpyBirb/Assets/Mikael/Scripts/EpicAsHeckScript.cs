using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EpicAsHeckScript : MonoBehaviour
{
    public int NumberOfDeaths;
    [SerializeField] Text TheTextForDeaths;

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
        UpdateLivesText();
    }

    public void IncreaseDeathNum()
    {
        NumberOfDeaths++;
        if (NumberOfDeaths == 3)
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
        TheTextForDeaths.text = "Deaths: " + NumberOfDeaths;
    }

    private void TheUnthinkableOption()
    {
        Debug.Log("Losing 3 times? UNTHINKABLE");
    }
}
