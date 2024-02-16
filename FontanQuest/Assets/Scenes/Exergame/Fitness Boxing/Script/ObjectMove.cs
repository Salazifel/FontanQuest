using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float speed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed*Time.deltaTime, 0);
    }



    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SmartWatchData.pastHeartActivity == true || SmartWatchData.pastStepActivitiy == true)
        {
            if (collision.gameObject.tag == "SmallCube1")
            {
                gameObject.SetActive(false);
                transform.parent.GetComponent<PunchManager>().SpawnPunch1();
            }
            else if (collision.gameObject.tag == "SmallCube2")
            {
                gameObject.SetActive(false);
                transform.parent.GetComponent<PunchManager>().SpawnPunch2();
            }
        }
        else if (SmartWatchData.pastHeartActivity6sec == true && SmartWatchData.pastStepActivitiy6sec == true)
        {
            if (collision.gameObject.tag == "SmallCube1")
            {
                gameObject.SetActive(false);
                transform.parent.GetComponent<PunchManager>().SpawnPunch1();
            }
            else if (collision.gameObject.tag == "SmallCube2")
            {
                gameObject.SetActive(false);
                transform.parent.GetComponent<PunchManager>().SpawnPunch2();
            }
        }

    }

}
