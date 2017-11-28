using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    public bool gripButtonDown = false;
    public bool gripButtonUp = false;
    public bool gripButtonPressed = false;

    public bool triggerButtonDown = false;
    public bool triggerButtonUp = false;
    public bool triggerButtonPressed = false;


    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
        
    }
    private SteamVR_TrackedObject trackedObj;

    private GameObject pickup;


	// Use this for initialization
	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller == null)
        {
            Debug.Log("Controller not initialized.");
            return;
        }

        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);
        gripButtonPressed = controller.GetPress(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);

        if(gripButtonDown)
        {
            Debug.Log("Grip button was just pressed.");
        }

        if (gripButtonDown && pickup != null)
        {
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (gripButtonUp)
        {
            Debug.Log("Grip button was just unpressed.");
        }

        if (gripButtonUp && pickup != null)
        {
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().isKinematic = false;
        }

        if (triggerButtonDown)
        {
            Debug.Log("Trigger button was just pressed.");
        }

        if (triggerButtonUp)
        {
            Debug.Log("Trigger button was just unpressed.");
        }

        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger entered");
    }

}
