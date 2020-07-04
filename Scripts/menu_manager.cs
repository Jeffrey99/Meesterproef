using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_manager : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    private bool creditsscreen;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startClick()
    {
        Application.LoadLevel(1);
    }
    public void quitClick()
    {
        Application.Quit();
    }
    public void creditsClick()
    {
        creditsscreen = !creditsscreen;
        if (creditsscreen) {
            credits.SetActive(true);
        }        
        if (!creditsscreen) {
            credits.SetActive(false);   
        }
    }
}
