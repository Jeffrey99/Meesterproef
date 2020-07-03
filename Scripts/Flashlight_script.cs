using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight_script : MonoBehaviour
{
    [Header("CONTROLS")]
    [SerializeField] private GameObject follow;
    [SerializeField] private GameObject spherelight;
    [SerializeField] private float followspeed;
    [SerializeField] private KeyCode reloadbutton;
    [SerializeField] private KeyCode powerbutton;
    private bool power;

    [Header("DISTANCER")]
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    [SerializeField] private float maxAngle;
    [SerializeField] private float minAngle;

    [Header("BATTERIES")]
    [SerializeField] private float batteries;
    [SerializeField] private float batterylife;
    [SerializeField] private Image batterybar;
    [SerializeField] private Text batteriesleft;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Light>().range = minRange;
        power = true;
    }

    // Update is called once per frame
    void Update()
    {
        batteriesleft.text = batteries.ToString();
        batterybar.fillAmount = batterylife;
        this.transform.position = Vector3.Lerp(this.transform.position, follow.transform.position, followspeed * Time.deltaTime);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, follow.transform.rotation, followspeed * Time.deltaTime);
        if (batteries >= 0)
        {
            if (batterylife > 0)
            {
                if (power)
                {
                    batterylife -= 0.05f * Time.deltaTime;
                }
                if (Input.GetKeyDown(powerbutton))
                {
                    power = !power;
                    if (power)
                    {
                        this.GetComponent<Light>().enabled = true;
                        this.GetComponent<Aura2API.AuraLight>().enabled = true;

                        spherelight.GetComponent<Light>().enabled = true;
                    }
                    if (!power)
                    {
                        this.GetComponent<Light>().enabled = false;
                        this.GetComponent<Aura2API.AuraLight>().enabled = false;

                        spherelight.GetComponent<Light>().enabled = false;

                    }
                }
                if (Input.GetMouseButtonDown(1))
                {
                    this.GetComponent<Light>().range = maxRange;
                    this.GetComponent<Light>().spotAngle = maxAngle;

                }
                if (Input.GetMouseButtonUp(1))
                {
                    this.GetComponent<Light>().range = minRange;
                    this.GetComponent<Light>().spotAngle = minAngle;
                }
                if (Input.GetKeyDown(reloadbutton) && batteries > 0)
                {
                    batterylife = 1;
                    batteries -= 1;
                }
            }
            if (batterylife < 0)
            {
                power = false;
                this.GetComponent<Light>().enabled = false;
                this.GetComponent<Aura2API.AuraLight>().enabled = false;
                spherelight.GetComponent<Light>().enabled = false;

                if (Input.GetKeyDown(reloadbutton) && batteries > 0)
                {
                    batterylife = 1;
                    batteries -= 1;
                }
            }
        }
    }

    public void addBattery()
    {
        batteries += 1;
    }
}
