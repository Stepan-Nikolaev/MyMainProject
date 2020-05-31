using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crops : MonoBehaviour
{
    [SerializeField] protected int _countPortions;
    [SerializeField] protected Image _iconHarvest;
    [SerializeField] protected float _growthTime;

    public int GetCountPortions()
    {
        return _countPortions;
    }

    public float GetGrowthTime()
    {
        return _growthTime;
    } 

    public void TurnIcon()
    {
        Image imageIcon = gameObject.GetComponent<Image>();

        imageIcon.enabled = !imageIcon.enabled;
    }
}
