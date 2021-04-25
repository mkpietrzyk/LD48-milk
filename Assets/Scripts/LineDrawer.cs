using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
   [SerializeField] private float distance;
   [SerializeField] private Camera mainCamera;
   
   private LineRenderer _lineRenderer;
   private Vector3 _origin;
   private GameObject _originObject;
   [SerializeField] private string originID;
   [SerializeField] private string targetID;

   public StringVariable selectedObjectID;
   public IntVariable householdsCounter;
   public IntVariable connectionsCounter;
   public IntVariable cash;
   public FloatVariable connectionsDistance;

   public GameObject connections;

   public GameObject target;

   private void OnEnable()
   {
      _lineRenderer = GetComponent<LineRenderer>();
      _lineRenderer.positionCount = 2;
      mainCamera = Camera.main;
      originID = selectedObjectID.Value;
      connections = GameObject.FindWithTag("connectionsContainer");
      transform.parent = connections.transform;
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
            _originObject = GameObject.FindWithTag("selected");
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
                  target = raycastHit.transform.gameObject;
                  targetID = target.GetComponent<Household>().uniqueID;
               }
               else
               {
                  _lineRenderer.SetPosition(1, new Vector3(raycastHit.point.x, 0.5f, raycastHit.point.z));
                  targetID = "";
                  target = null;
               }
               distance = (raycastHit.point - _origin).magnitude;
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
               bool isPossibleToBuy = cash.Value > householdsCounter.Value * 20;
               if (isPossibleToBuy)
               {
                  bool isTargetNotSetFrom = String.IsNullOrEmpty(target.GetComponent<Household>().connectedFrom);
                  bool isOriginHousehold = _originObject.GetComponent<Household>();
                  if (isTargetNotSetFrom)
                  {
                     target.GetComponent<Household>().connectedFrom = originID;
                     if (isOriginHousehold)
                     {
                        _originObject.GetComponent<Household>().connectedTo = targetID;
                     }
                     cash.Value -= householdsCounter.Value * 20;
                     householdsCounter.Value += 1;
                     connectionsDistance.Value += distance;
                     connectionsCounter.Value += 1;
                     selectedObjectID.Value = "";

                  }
                  else
                  {
                     Destroy(gameObject);
                  }
               }
               else
               {
                  Destroy(gameObject);
               }
            }
         }
      }
   }
}
