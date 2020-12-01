using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]

public class Crops : MonoBehaviour
{
    [SerializeField] protected int _countPortions;
    [SerializeField] protected float _growthTime;
    protected Image _iconHarvest;

    public int GetCountPortions
    {
        get
        {
            return _countPortions;
        }
    }

    public float GetGrowthTime
    {
        get
        {
            return _growthTime;
        }
    }

    private void Start()
    {
        _iconHarvest = GetComponent<Image>();
    }

    public void ViewIcon()
    {

        _iconHarvest.enabled = !_iconHarvest.enabled;
    }
}
