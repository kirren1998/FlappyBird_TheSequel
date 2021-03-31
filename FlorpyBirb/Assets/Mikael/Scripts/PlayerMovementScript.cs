using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float UpwardsMomentum = 2f;
    float OriginalUpwardMomentum = 0;
    bool GoingUp = false;

    Rigidbody2D TheBirbBody;

    // Start is called before the first frame update
    void Start()
    {
        OriginalUpwardMomentum = UpwardsMomentum;
        TheBirbBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GoingUp = true;
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
    }
}
