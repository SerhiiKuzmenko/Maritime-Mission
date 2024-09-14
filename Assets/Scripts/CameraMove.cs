using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject referense;

    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        transform.position = referense.transform.position+ new Vector3(0,0,-10);
    }

}
