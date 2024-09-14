using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TargetSearcher : MonoBehaviour
{
    [SerializeField] private GameObject _img;
    [SerializeField] private GameObject _boat;
    [SerializeField] int calibr = 20;
    //bool hasResource = false;
    ResourceCollector collector;

    void Start()
    {
        collector = FindObjectOfType<ResourceCollector>();
    }
    

    void Update()
    {
       
        
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Resource");
        GameObject _rig = GameObject.FindGameObjectWithTag("Checkpoint");
        if (collector.getResuorceStatus() == false)
        {
            if (targetObjects.Length > 0)
            {
                GameObject nearestTarget = GetNearestTarget(targetObjects);
                if (nearestTarget != null)
                {
                    Vector3 directionToTarget = (nearestTarget.transform.position - _boat.transform.position).normalized;

                    float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                    _img.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - calibr));
                }

            }
        }
        else
        {
            Vector3 directionToTarget = (_rig.transform.position - _boat.transform.position).normalized;

            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            _img.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - calibr));
        }

        

        
    }


    private GameObject GetNearestTarget(GameObject[] targets)
    {
        float minDist = float.MaxValue;
        GameObject nearestTarget = null;

        foreach(GameObject target in targets)
        {
            float dist = Vector3.Distance(_boat.transform.position, target.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }
}
