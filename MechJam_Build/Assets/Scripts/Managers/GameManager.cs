using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public KaijuManager Manager_Kaiju;
    public MechManager Manager_Mech;
    //needs to hold onto engine, power supply, lights, 
    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);


    }

    

}
