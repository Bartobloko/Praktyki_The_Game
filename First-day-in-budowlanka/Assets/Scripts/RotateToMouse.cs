using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
      [SerializeField] private Camera mainCamera;
     private Transform aimTransform;
     private void Awake() {
          aimTransform = transform.Find("Aim");
     }
    void Update() {
         Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
         mouseWorldPosition.z = 0f;
         Vector3 aimDirection = (mouseWorldPosition - transform.position).normalized;
         float angle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0,angle);
    }
}
