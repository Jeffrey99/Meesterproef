using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_script : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private KeyCode pickupbutton;

    [SerializeField] private GameObject flashlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam = Camera.main;
        RaycastHit hit;
        Vector3 CameraCenter = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, cam.nearClipPlane));
        if (Physics.Raycast(CameraCenter, cam.transform.forward, out hit, 5))
        {
            if(hit.transform.tag == "Battery")
            {
                if (Input.GetKeyDown(pickupbutton))
                {
                    Destroy(hit.transform.gameObject);
                    flashlight.GetComponent<Flashlight_script>().addBattery();
                }
            }
        }
    }
}
