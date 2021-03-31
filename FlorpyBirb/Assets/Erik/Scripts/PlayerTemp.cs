using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{
    public Settings settings;
    [Range(10, 100)]public float moveSpeed;
    public bool rampMeUpScotty = false;
    [Range(0.1f, 1)]public float speedRamp;
    private void Start()
    {
        settings = Settings.settings;
        StartCoroutine(DoTheRamp(10));
    }
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        if (rampMeUpScotty) moveSpeed = Mathf.Clamp(moveSpeed += Time.deltaTime * speedRamp * (int)settings.difficulty, 10, 30 + 10 * (int)settings.difficulty);
    }
    public IEnumerator DoTheRamp(float timer)
    {
        yield return new WaitForSecondsRealtime(timer - (int)settings.difficulty);
        rampMeUpScotty = true;
        yield return new WaitForSecondsRealtime(1f);
        rampMeUpScotty = false;
        StartCoroutine(DoTheRamp(10));
    }
    public void Death()
    {
        StopAllCoroutines();
    }
}
