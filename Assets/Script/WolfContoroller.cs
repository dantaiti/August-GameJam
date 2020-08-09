using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfContoroller : MonoBehaviour
{ 
    [HideInInspector] public Vector3 hitPoint = Vector3.zero;
    [SerializeField] private Transform follow = default;
    [SerializeField] private Vector3 followOffset = Vector3.zero;
    public Transform target = default;
    [SerializeField] private Vector3 targetOffset = Vector3.zero;
    private Camera _cam = default;
    private LineRenderer _line = default;
    
    const int LinePoints = 5;

  
   

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _line = GetComponentInChildren<LineRenderer>();
        _line.positionCount = LinePoints;
    }

    void Update()
    {
        UpdateMousePosition();
       
    }

    void UpdateMousePosition()
    {
        RaycastHit hit;
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            hitPoint = hit.point;
            target.position = hit.point + targetOffset;
            target.up = Vector3.Lerp(target.up, hit.normal, .3f);
            for (int i = 0; i < LinePoints; i++)
            {
                Vector3 linePos = Vector3.Lerp(follow.position + followOffset, target.position, (float)i / 5f);
                _line.SetPosition(i, linePos);
            }
        }
    }

    
}


