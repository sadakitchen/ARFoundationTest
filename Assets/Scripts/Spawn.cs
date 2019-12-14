using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastHit))]
public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject m_SpawnPrefab;

    private readonly List<ARRaycastHit> _hitResults = new List<ARRaycastHit>();
    private ARRaycastManager _rayManage;

    private void Awake()
    {
        _rayManage = this.GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_rayManage.Raycast(Input.GetTouch(0).position, _hitResults, TrackableType.PlaneWithinPolygon))
            {
                Instantiate(m_SpawnPrefab, _hitResults[0].pose.position, Quaternion.identity);
            }
        }
    }
}