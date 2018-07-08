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
    private AudioSource snareSound;
    private AudioSource bassSound;
    private AudioSource tomSound;

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log(vb.VirtualButtonName);
        switch (vb.VirtualButtonName) {
            case "hiHatButton" :
                Debug.Log("Hihat pressed");
                //Play music
                hiHatSound.Play();
                //Spin cube
                break;
            case "snareButton" :
                Debug.Log("Snare pressed");
                snareSound.Play();
                break;
            case "bassButton" :
                Debug.Log("Bass pressed");
                bassSound.Play();
                break;
            case "tomButton" :
                Debug.Log("Tom pressed");
                tomSound.Play();
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        stopAllSound();
    }

    private void stopAllSound()
    {
        hiHatSound.Stop();
        snareSound.Stop();
        bassSound.Stop();
        tomSound.Stop();
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

        // Setting up audio sources
        AudioSource[] audiosrcs = GetComponentsInChildren<AudioSource>();
        hiHatSound = audiosrcs[0];
        snareSound = audiosrcs[1];
        bassSound = audiosrcs[2];
        tomSound = audiosrcs[3];

        stopAllSound();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
