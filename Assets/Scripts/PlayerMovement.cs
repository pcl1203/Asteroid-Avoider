using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   private Camera mainCamera;
   private Rigidbody rb;
   private Vector3 movementDirection;

   [SerializeField] private float forceMagnitude;
   [SerializeField] private float maxVelocity;

   // Start is called before the first frame update
   void Start()
   {
      rb = GetComponent<Rigidbody>();
      mainCamera = Camera.main;

   }

   // Update is called once per frame
   void Update()
   {
      ProcessInput();
      KeepPlayerOnScreen();
   }

   private void KeepPlayerOnScreen()
   {
      Vector3 newPosition = transform.position;
      Vector3 viewPortPos = mainCamera.WorldToViewportPoint(transform.position);
      if (viewPortPos.x > 1) {
         newPosition.x = -newPosition.x + 0.1f;
      } else if (viewPortPos.x < 0) {
         newPosition.x = -newPosition.x - 0.1f;
      }

      if (viewPortPos.y > 1)
      {
         newPosition.y = -newPosition.y + 0.1f;
      }
      else if (viewPortPos.y < 0)
      {
         newPosition.y = -newPosition.y - 0.1f;
      }

      transform.position = newPosition;
   }

   void FixedUpdate()  
   {
      if (movementDirection == Vector3.zero) return;

      rb.AddForce(movementDirection * forceMagnitude, ForceMode.Force);// no need to add Time.deltaTime
      rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
   }
   private void ProcessInput()
   {
      if (Touchscreen.current.primaryTouch.press.isPressed)
      {
         Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
         Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPosition);

         movementDirection = transform.position - worldPos;
         movementDirection.z = 0f;
         movementDirection.Normalize();

      }
      else
      {
         movementDirection = Vector3.zero;
      }
   }
}
