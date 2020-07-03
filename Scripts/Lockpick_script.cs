using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockpick_script : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lockpick;
    private bool solved;
    private float distance;
    public Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        rot = lockpick.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance < 2 && Input.GetKeyDown(KeyCode.E))
        {
            lockpick.SetActive(true);
        }

        if (lockpick.active)
        {
            lockpick.transform.Rotate(Vector3.up * 2500 * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime);
        }

        if(distance > 2)
        {
            lockpick.SetActive(false);
            lockpick.transform.rotation = rot;
        }
    }
   
}
