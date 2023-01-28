using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private int _hitsToCutDown = 1;
    private int _hits = 0;
    [SerializeField]
    private int superHitValue = 3;
    public Action CutDown;

    public void Hit()
    {
        _hits++;
        if (_hits == _hitsToCutDown)
        {
            CutDown?.Invoke();
        }
    }
    public void SuperHit()
    {
        _hits += superHitValue;
        if (_hits >= _hitsToCutDown)
        {
            CutDown?.Invoke();
        }
    }
}
