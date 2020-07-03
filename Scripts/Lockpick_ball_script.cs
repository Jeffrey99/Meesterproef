using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick_ball_script : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject lockpick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "lockpickComplete")
        {
            lockpick.SetActive(false);
            door.GetComponent<Animator>().Play("Door_Opened");
        }
    }
}
