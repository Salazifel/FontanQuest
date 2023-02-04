using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    #region Instance
    private static Accelerometer instance;
    public static Accelerometer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Accelerometer>();
                if (instance == null)
                {
                    instance = new GameObject("Spawend Accelerometer", typeof(Accelerometer)).GetComponent<Accelerometer>();
                }
            }
            return instance;
        }
        set { instance = value; }
    }
    #endregion

    [Header("Shake Detection")]
    public Action OnChop;
    public Action OnSuperChop;
    [SerializeField] private float threshold = 3.2f;
    [SerializeField] private float superThreshold = 6.0f;

    private bool hitAlreadyCounted = false;

    private void Start()
    {
    }
    void Update()
    {
        Vector3 acceleration = Input.acceleration;

        //if y > threshold the hit will be counted, 
        // when hit counted is still false than the hit has already been counted
        if ((acceleration.y > threshold) & (acceleration.y < superThreshold) & (hitAlreadyCounted == false))
        {
            OnChop?.Invoke();
            hitAlreadyCounted = true;

        }
        else if (acceleration.y > superThreshold & hitAlreadyCounted == false)
        {
            OnSuperChop?.Invoke();
            hitAlreadyCounted = true;
        }
        // if y < 0 backward movement --> new hit will come
        if (acceleration.y < 0)
        {
            hitAlreadyCounted = false;
        }
    }
}
