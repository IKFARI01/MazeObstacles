using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


namespace ClassDemos
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        float speed = 5.0f;
        [SerializeField]
        float rotation = 5.0f;
        [SerializeField]
        float jumpForce = 10f;

        public PlayerControlMappings playerControls;
        public GameObject bulletPrefab;
        public Transform BulletSpawnTransform;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;
        private bool grounded;

        private InputAction move;
        private InputAction look;
        private InputAction jump;
        //private InputAction fire;

        Rigidbody rb;

        private void Awake()
        {
            playerControls = new PlayerControlMappings();

            rb = GetComponent<Rigidbody>();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            move = playerControls.Player.Move;
            jump = playerControls.Player.Jump;
            look = playerControls.Player.Look;
            //fire = playerControls.Player.Fire;
        }

        private void OnEnable()
        {
            move.Enable();
            look.Enable();

            jump.Enable();
            jump.performed += Jump;

            //fire.Enable();
            //fire.performed += Fire;

        }

        private void OnDisable()
        {
            move.Disable();
            jump.Disable();
            look.Disable();
            //fire.Disable();
        }


        private void Update()
        {
            HandleHorizontalRotation();
            HandleVerticalRotation();
        }

        private void FixedUpdate()
        {
            //grounded = IsGrounded();

            HandleMovement();
        }

        void HandleMovement()
        {
            //if (grounded == false) return;

            Vector2 axis = move.ReadValue<Vector2>();

            Vector3 input = (axis.x * transform.right) + (transform.forward * axis.y);

            input *= speed;

            rb.velocity = new Vector3(input.x, rb.velocity.y, input.z);
        }

        //bool IsGrounded()
        //{
        //    // Bit shift the index of the layer (8) to get a bit mask
        //    int layerMask = 1 << 3;

        //    RaycastHit hit;

        //    // Does the ray intersect any objects excluding the player layer
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask))
        //    {
        //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * -1) * hit.distance, Color.yellow);
        //        return true;
        //    }
        //    else
        //    {
        //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //        return false;
        //    }
        //}

        void HandleHorizontalRotation()
        {

            mouseDeltaX = look.ReadValue<Vector2>().x;

            if (mouseDeltaX != 0)
            {
                rotDir = mouseDeltaX > 0 ? 1 : -1;

                transform.eulerAngles += new Vector3(0, rotation * Time.deltaTime * rotDir, 0);
            }
        }

        void HandleVerticalRotation()
        {
            mouseDeltaY = look.ReadValue<Vector2>().y;

            if (mouseDeltaY != 0)
            {
                rotDir = mouseDeltaY > 0 ? -1 : 1;

                cameraRotX += rotation * Time.deltaTime * rotDir;
                cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

                var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);


                //Vector3 angle = new Vector3(rotation * Time.deltaTime * rotDir, 0, 0);

                //Debug.Log(Camera.main.transform.localRotation.x);

                Camera.main.transform.localRotation = targetRotation;
                //Camera.main.transform.Rotate(angle, Space.Self);

            }
        }

        void Jump(InputAction.CallbackContext context)
        {
            //if (grounded == false) return;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("I jumped!");
        }
        //Demo stuff
        //void Fire(InputAction.CallbackContext context)
        //{

        //    Debug.Log("I Fire!");
        //    Instantiate(bulletPrefab, transform.position, Camera.main.transform.rotation); ;

        //}
    }
}
