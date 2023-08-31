using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public MonoBehaviour player;
    Vector3 cameraOffset = new Vector3(0, 7, -20); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // `LateUpdate()` is called once per frame after all other scripts' `Update()s` have finished
    // `LateUpdate()` is good for camera updates if tailing object and  UI updates
    void LateUpdate()
    {
        this.transform.position = player.transform.position + cameraOffset;
    }
}
