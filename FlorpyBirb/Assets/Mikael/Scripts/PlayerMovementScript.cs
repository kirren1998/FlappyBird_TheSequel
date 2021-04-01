using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float UpwardsMomentum = 2f;
    [SerializeField] float CooldownInSecond = 2f;
    [SerializeField] float AttackInSeconds = 0.5f;
    [SerializeField] bool ComputerMoveset = false;
    [SerializeField] GameObject ActiveObjectCheck = null;
    [SerializeField] GameObject ReactivatedObjectCheck = null;
    [SerializeField] AudioClip TheSlaps = null;
    float CooldownCurrent = 0;
    float AttackInSecondsLeft = 0;
    bool GoingUp = false;
    public bool SlappingEnemy = false;
    bool OnGoingSlap = false;
    [SerializeField] GameObject SlapHandObject;
    Vector2 MouseLocation;

    public bool IsAlive = true;
    public bool IsActive = false;
    float NormalGrav;

    float WindowsSizeX = 100f;

    Rigidbody2D TheBirbBody;

    // Start is called before the first frame update
    void Start()
    {
        TheBirbBody = GetComponent<Rigidbody2D>();

        WindowsSizeX = Screen.width;

        NormalGrav = TheBirbBody.gravityScale;
        TheBirbBody.gravityScale = 0;

        if (ReactivatedObjectCheck != null)
        {
            ReactivatedObjectCheck.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseLocation = Input.mousePosition;
        if (ActiveObjectCheck.activeSelf == false && !IsActive)
        {
            IsActive = true;
            TheBirbBody.gravityScale = NormalGrav;
        }
        if (IsAlive)
        {
            if (ComputerMoveset)
            {
                if (Input.GetButton("Fire1"))
                {
                    GoingUp = true;
                }
                if (Input.GetButtonDown("Fire2"))
                {
                    SlappingEnemy = true;
                    CooldownCurrent = CooldownInSecond;
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (MouseLocation.x <= WindowsSizeX * 0.5f)
                    {
                        GoingUp = true;
                    }
                    else if (MouseLocation.x >= WindowsSizeX * 0.5f && CooldownCurrent <= 0 && Input.GetButtonDown("Fire1"))
                    {
                        SlappingEnemy = true;
                        CooldownCurrent = CooldownInSecond;
                    }
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    GoingUp = false;
                }
            }
        }
        else
        {
            if (GoingUp)
            {
                GoingUp = false;
            }
            if (SlappingEnemy)
            {
                SlappingEnemy = false;
            }
        }
    }

    // Update frames at specific intervals
    private void FixedUpdate()
    {
        if (GoingUp)
        {
            TheBirbBody.AddForce(Vector2.up * Mathf.Clamp(UpwardsMomentum * 9.8f, 0.2f, UpwardsMomentum), ForceMode2D.Impulse);
            if (ComputerMoveset)
            {
                GoingUp = false;
            }
        }
        if (SlappingEnemy && !OnGoingSlap)
        {
            SlapHandObject.SetActive(true);
            Debug.Log("SLAP!");
            AttackInSecondsLeft = AttackInSeconds;
            OnGoingSlap = true;
            if (TheSlaps)
            {
                AudioSource.PlayClipAtPoint(TheSlaps, Camera.main.transform.position, 0.5f);
            }
        }
        if (AttackInSecondsLeft > 0)
        {
            AttackInSecondsLeft -= Time.deltaTime;
        }
        else if (SlappingEnemy)
        {
            SlapHandObject.SetActive(false);
            OnGoingSlap = false;
            SlappingEnemy = false;
        }
        if (!SlappingEnemy && CooldownCurrent > 0)
        {
            CooldownCurrent -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && IsAlive)
        {
            DoDeathAction();
        }
    }

    private void DoDeathAction()
    {
        Debug.Log("Dead");
        IsAlive = false;
        if (GetComponent<PlayerTemp>())
        {
            GetComponent<PlayerTemp>().Death();
        }
        if (FindObjectOfType<EpicAsHeckScript>())
        {
            FindObjectOfType<EpicAsHeckScript>().IncreaseDeathNum();
        }
        if (FindObjectOfType<DestroyShitTemp>())
        {
            FindObjectOfType<DestroyShitTemp>().SetHighScore();
        }
        if (ReactivatedObjectCheck.activeSelf == false)
        {
            if (FindObjectOfType<EpicAsHeckScript>())
            {
                if (FindObjectOfType<EpicAsHeckScript>().DoTheUnthinkable())
                {
                    Invoke("ReactivateButton", 20f);
                }
                else
                {
                    Invoke("ReactivateButton", 1f);
                }
            }
            else
            {
                Invoke("ReactivateButton", 1f);
            }
        }
    }

    private void ReactivateButton()
    {
        if (ReactivatedObjectCheck != null)
        {
            ReactivatedObjectCheck.SetActive(true);
        }
    }
}
