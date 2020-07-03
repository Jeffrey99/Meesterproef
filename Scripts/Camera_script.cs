using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_script : MonoBehaviour
{
    [Header("CONTROLS")]
    public bool power;
    public Camera cam;
    private float timetofilm;
    [SerializeField] private float Lookat_timer;
    [SerializeField] private float rotatespeed;
    [SerializeField] private GameObject follow;
    [SerializeField] private float followSpeed;
    [SerializeField] private KeyCode powerbutton;
    [SerializeField] private float evidenceFilmed;

    [Header("UI")]
    [SerializeField] private GameObject recordingCircle;

    // Start is called before the first frame update
    void Start()
    {
        power = false;
        evidenceFilmed = 0;
    }

    // Update is called once per frame

    void Update()
    {
        if (evidenceFilmed == 5) 
            
            {
                Application.LoadLevel(2);
            }
        this.transform.position = follow.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, follow.transform.rotation, rotatespeed * Time.deltaTime);
        if (Input.GetKeyDown(powerbutton))
        {
            power = !power;
            if (power)
            {
                this.GetComponent<Animator>().SetBool("showCam", true);
            }
            if (!power)
            {
                this.GetComponent<Animator>().SetBool("showCam", false);
            }
        }
        RaycastHit hit;
        Vector3 CameraCenter = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, cam.nearClipPlane));
        if (Physics.Raycast(CameraCenter, cam.transform.forward, out hit, 5))
        {
            if (hit.transform.tag == "Evidence")
            {
                recordingCircle.SetActive(true);
                timetofilm += Lookat_timer * Time.deltaTime;
                recordingCircle.GetComponent<Image>().fillAmount = timetofilm;
                if(timetofilm > 1)
                {
                    recordingCircle.SetActive(false);
                    timetofilm = 0;
                    evidenceFilmed += 1;
                    Transform solv;
                    solv = hit.transform.GetChild(0);
                    solv.transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    hit.transform.tag = "Evidence_Solved";
                }
            }
        }
        else
        {
            recordingCircle.SetActive(false);
            timetofilm = 0;
        }
    }
}
