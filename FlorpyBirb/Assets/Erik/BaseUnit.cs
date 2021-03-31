using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [Range(1, 10)] public float moveSpeed;
    [Range(1, 10)] public float iratickness;
    [Range(1, 5)] public int worth;
}
