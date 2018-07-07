using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class button_effect : MonoBehaviour, IVirtualButtonEventHandler {

    private GameObject virtualHiHatButton;
    private GameObject virtualSnareButton;
    private GameObject virtualBassButton;
    private GameObject virtualTomButton;

    private AudioSource hiHatSound;
    private AudioClip hihat;

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log(vb.VirtualButtonName);
        //When a virtual button is pressed
        switch (vb.VirtualButtonName) {
            case "hiHatButton" :
                Debug.Log("Hihat pressed");

                //Play music
                hiHatSound.Play();
                //Spin cube
                break;
            case "snareButton" :
                Debug.Log("Snare pressed");

                break;
            case "bassButton" :
                Debug.Log("Bass pressed");

                break;
            case "tomButton" :
                Debug.Log("Tom pressed");

                break;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        //Nothing is done when button is released
    }

    // Use this for initialization
    void Start()
    {

        // Children from this ImageTarget with type VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterEventHandler(this);
        }

        AudioSource[] audiosrcs = GetComponentsInChildren<AudioSource>();
        hiHatSound = audiosrcs[0];


        /*
        virtualHiHatButton = GameObject.Find("hiHatButton");
        virtualSnareButton = GameObject.Find("snareButton");
        virtualTomButton = GameObject.Find("tomButton");
        virtualBassButton = GameObject.Find("bassButton");

        virtualHiHatButton.SetActive(true);
        virtualSnareButton.SetActive(true);
        virtualTomButton.SetActive(true);
        virtualBassButton.SetActive(true); */
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
