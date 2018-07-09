using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class button_effect : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject purpleCube;
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject greenCube;

    private AudioSource hiHatSound;
    private AudioSource snareSound;
    private AudioSource bassSound;
    private AudioSource tomSound;

    private static Color blue;
    private static Color red;
    private static Color green;
    private static Color purple;

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log(vb.VirtualButtonName);
        switch (vb.VirtualButtonName) {
            case "hiHatButton" :
                blueCube.GetComponent<Renderer>().material.color = Color.white;
                hiHatSound.Play();
                break;
            case "snareButton" :
                greenCube.GetComponent<Renderer>().material.color = Color.white;
                snareSound.Play();
                break;
            case "bassButton" :
                redCube.GetComponent<Renderer>().material.color = Color.white;
                bassSound.Play();
                break;
            case "tomButton" :
                purpleCube.GetComponent<Renderer>().material.color = Color.white;
                tomSound.Play();
                break;
        }
    }


    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        StopSound();

        //Changing cubes to original colors
        blueCube.GetComponent<Renderer>().material.color = blue;
        redCube.GetComponent<Renderer>().material.color = red;
        purpleCube.GetComponent<Renderer>().material.color = purple;
        greenCube.GetComponent<Renderer>().material.color = green;
 
    }


    private void InitAudio()
    {
        // Setting up audio sources
        AudioSource[] audiosrcs = GetComponentsInChildren<AudioSource>();
        hiHatSound = audiosrcs[0];
        snareSound = audiosrcs[1];
        bassSound = audiosrcs[2];
        tomSound = audiosrcs[3];

        // Make sure sounds don't play on initialization
        StopSound();
    }


    private void StopSound() 
    {
        hiHatSound.Stop();
        snareSound.Stop();
        bassSound.Stop();
        tomSound.Stop();
    }


    private void InitColors() 
    {
        // Initialize original colors of the cubes

        blue = blueCube.GetComponent<Renderer>().material.color;
        red = redCube.GetComponent<Renderer>().material.color;
        purple = purpleCube.GetComponent<Renderer>().material.color;
        green = greenCube.GetComponent<Renderer>().material.color;
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

        InitAudio();
        StopSound();
        InitColors();

	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
