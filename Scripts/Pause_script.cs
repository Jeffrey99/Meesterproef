using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause_script : MonoBehaviour
{

    [SerializeField] private GameObject pause_screen;
    [SerializeField] private GameObject settingscreen;
    [SerializeField] private GameObject fps;

    [SerializeField] private GameObject main;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject AudioSettings;
    [SerializeField] private GameObject ControlSettings;
    [SerializeField] private GameObject GraphicSettings;
    [SerializeField] private Camera cam;
    private bool esc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc = !esc;
            if (esc)
            {
                pause_screen.SetActive(true);
                fps.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            if (!esc)
            {
                continueclick();
            }
        }
    }
    public void continueclick()
    {
        pause_screen.SetActive(false);
        settingscreen.SetActive(false);
        exit.SetActive(false);
        fps.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Time.timeScale = 1;
        exit.SetActive(false);
    }
    public void Exitclick()
    {
        exit.SetActive(true);
    }
    public void Exitclickyes()
    {
        continueclick();
        Application.LoadLevel(0);
    }
    public void Exitclickno()
    {
        exit.SetActive(false);
    }

    public void settingclick() {
        settingscreen.SetActive(true);
    }

    public void auraon() {
        cam.GetComponent<Aura2API.AuraCamera>().enabled = true;
    }
    public void auraoff() {
        cam.GetComponent<Aura2API.AuraCamera>().enabled = false;
    }
}
