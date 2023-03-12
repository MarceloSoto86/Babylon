using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera enemySpawnCam;
    public Camera tacticalCam;
    public Camera birdCam;
    // public Camera wormCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            EnemySpawnCam();
        }

        if (Input.GetKeyUp("2"))
        {
            TacticalCam();
        }
        if (Input.GetKeyUp("3"))
        {
            BirdCam();
        }
        /* if (Input.GetKeyUp("4"))
         {
             WormCam();
         }*/
    }

    public void TacticalCam()
    {
        tacticalCam.enabled = true;
        enemySpawnCam.enabled = false;
        birdCam.enabled = false;
        //wormCam.enabled = false;
    }

    public void EnemySpawnCam()
    {
        enemySpawnCam.enabled = true;
        tacticalCam.enabled = false;
        birdCam.enabled = false;
        //  wormCam.enabled = false;
    }

    /*  public void WormCam()
      {
          wideCam.enabled = false;
          closeCam.enabled = false;
          birdCam.enabled = false;
          wormCam.enabled = true;
      }*/

    public void BirdCam()
    {
        enemySpawnCam.enabled = false;
        tacticalCam.enabled = false;
        birdCam.enabled = true;
        //wormCam.enabled = false;
    }

}