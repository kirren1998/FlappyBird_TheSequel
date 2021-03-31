using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float UpwardsMomentum = 2f;
    [SerializeField] float CooldownInSecond = 2f;
    [SerializeField] float AttackInSeconds = 0.5f;
    [SerializeField] bool ComputerMoveset = false;
    float CooldownCurrent = 0;
    float AttackInSecondsLeft = 0;
    bool GoingUp = false;
    public bool SlappingEnemy = false;
    bool OnGoingSlap = false;
    [SerializeField] GameObject SlapHandObject;
    Vector2 MouseLocation;

    float WindowsSizeX = 100f;

    Rigidbody2D TheBirbBody;

    // Start is called before the first frame update
    void Start()
    {
        TheBirbBody = GetComponent<Rigidbody2D>();

        WindowsSizeX = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLocation = Input.mousePosition;
        if (Input.GetButtonDown("Fire1"))
        {
            if (ComputerMoveset)
            {
                GoingUp = true;
            }
            else
            {
                if (MouseLocation.x <= WindowsSizeX * 0.5f)
                {
                    GoingUp = true;
                }
                else if (MouseLocation.x >= WindowsSizeX * 0.5f && CooldownCurrent <= 0)
                {
                    SlappingEnemy = true;
                    CooldownCurrent = CooldownInSecond;
                }
            }
        }
        else if (Input.GetButtonDown("Fire2") && ComputerMoveset)
        {
            SlappingEnemy = true;
            CooldownCurrent = CooldownInSecond;
        }
    }

    // Update frames at specific intervals
    private void FixedUpdate()
    {
        if (GoingUp)
        {
            TheBirbBody.AddForce(Vector2.up * UpwardsMomentum * 9.8f, ForceMode2D.Impulse);
            GoingUp = false;
        }
        if (SlappingEnemy && !OnGoingSlap)
        {
            SlapHandObject.SetActive(true);
            Debug.Log("SLAP!");
            AttackInSecondsLeft = AttackInSeconds;
            OnGoingSlap = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Dead");
        }
    }
}
