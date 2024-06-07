using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvents : MonoBehaviour
{
    public static UnityEvent<int> OnAddScorePoints = new();

    public static UnityEvent<float, float> UpdateUIHealthBar = new();
}
