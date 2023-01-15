using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bear : MonoBehaviour
{
    public int Live;
    private Animator animator;
    public Slider LiveSlider;

    public event DiedEvent Died;
    public delegate void DiedEvent();

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void Hit()
    {
        if (Live == 0)
        {
            Died?.Invoke();
            animator.SetTrigger("Died");
        }
        else
        {
            Live--;
            animator.ResetTrigger("Hit");
            LiveSlider.value = Live;
            animator.SetTrigger("Hit");
        }
    }
}
