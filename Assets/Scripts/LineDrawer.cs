using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
   [SerializeField] private float distance;
   [SerializeField] private LayerMask layerMask;
   [SerializeField] private Camera mainCamera;
   
   private LineRenderer _lineRenderer;
   private Vector3 _origin;

   public StringVariable selectedObjectID;

   private void Start()
   {
      _lineRenderer = GetComponent<LineRenderer>();
      _lineRenderer.positionCount = 2;
      // _mouseStartPosition = GameObject.FindWithTag("selected").transform.position;      
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         _origin = GameObject.FindWithTag("selected").transform.position;         
      }

      if (Input.GetMouseButton(0))
      {
         //_origin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
         Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out RaycastHit raycastHit))
         {
            if (raycastHit.transform.CompareTag("household"))
            {
               _lineRenderer.SetPosition(0, new Vector3(_origin.x, 0.2f ,_origin.z));
               _lineRenderer.SetPosition(1, raycastHit.transform.position);
            }
            else
            {
               _lineRenderer.SetPosition(0, new Vector3(_origin.x, 0.2f ,_origin.z));
               _lineRenderer.SetPosition(1, raycastHit.point);
            }
            distance = (raycastHit.point - _origin).magnitude;
         }
      }
   }
}
