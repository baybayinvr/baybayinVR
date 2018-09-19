using UnityEngine;
using System.Collections;

public class DrawLineManager : MonoBehaviour {

    // make public variable where the trackedObj trackedObj is called in awake 
    public SteamVR_TrackedObject trackedObj;

    private LineRenderer currLine;

    private int numClicks = 0;

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject go = new GameObject();
            currLine = go.AddComponent<LineRenderer>();

            numClicks = 0;
        }
        else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            {
                currLine.SetVertexCount(numClicks + 1);

                // keep adding vertices we want 

                currLine.SetPosition(numClicks, device.transform.pos); // 3d position of controller at any given point 
                numClicks++;
            }
        }
        }
    }  // as we build up our line we keep setting our index