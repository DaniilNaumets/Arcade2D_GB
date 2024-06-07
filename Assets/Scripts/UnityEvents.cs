using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvents : MonoBehaviour
{
    public static UnityEvent<float> OnAddScorePoints = new();

    public static UnityEvent<float, float> UpdateUIHealthBar = new();
    public static UnityEvent<float, float, int> UpdateUIScoreBar = new();
}
