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
   [SerializeField] private string originID;
   [SerializeField] private string targetID;

   public StringVariable selectedObjectID;
   public IntVariable householdsCounter;

   private void OnEnable()
   {
      _lineRenderer = GetComponent<LineRenderer>();
      _lineRenderer.positionCount = 2;
      mainCamera = Camera.main;
      originID = selectedObjectID.Value;
   }
   private void Update()
   {
      if (originID != selectedObjectID.Value)
      {
         
      }
      else
      {
         if (Input.GetMouseButtonDown(0))
         {
            _origin = GameObject.FindWithTag("selected").transform.position;         
         }

         if (Input.GetMouseButton(0))
         {
            _lineRenderer.SetPosition(0, new Vector3(_origin.x, 0.5f ,_origin.z));
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
               if (raycastHit.transform.CompareTag("household"))
               {
                  var position = raycastHit.transform.position;
                  float x = position.x;
                  float z = position.z;
                  _lineRenderer.SetPosition(1, new Vector3(x, 0.5f, z));
                  targetID = raycastHit.transform.gameObject.GetComponent<Household>().uniqueID;
               }
               else
               {
                  _lineRenderer.SetPosition(1, new Vector3(raycastHit.point.x, 0.5f, raycastHit.point.z));
                  targetID = "";
               }
               distance = (raycastHit.point - _origin).magnitude;
            }
         }
      }

      if (Input.GetMouseButtonUp(0))
      {
         if (targetID == "")
         {
            Destroy(gameObject);
         }
         else
         {
            householdsCounter.Value += 1;
            
         }
      }
   }
}
