using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Single Variable/SimpleFloatData")]
public class SimpleFloatData : ScriptableObject
{
    public float value; 

    public void UpdateValue(float amount)
    {
        value += amount;
    }

    public void SetValue(float amount)
    {
        value = amount;
    }
}
