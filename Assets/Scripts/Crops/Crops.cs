using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crops : MonoBehaviour
{
    [SerializeField] protected int _countPortions;
    [SerializeField] protected float _growthTime;
    protected Image _iconHarvest;

    private void Start()
    {
        _iconHarvest = GetComponent<Image>();
    }

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

        _iconHarvest.enabled = !_iconHarvest.enabled;
    }
}
