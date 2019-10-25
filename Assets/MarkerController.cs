using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    public int Lap = 1;
    public int MarkerPoint = 0;
    void OnTriggerEnter( Collider collision )
    {
        string yourTag  = collision.gameObject.tag;
        if( yourTag == "Player" )
        {
            MarkerPoint++;
        }
    }
}
