using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerControol")]
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -19.64f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    [Header("GraplingGun")]
    public GameObject PlayerCamera;
    [SerializeField] GameObject debugHitPointTransform;
    private State state;
    private Vector3 hookshotPosition;
    private Vector3 characterVelocityMomentum;
    public float maxGrapableDistance=50f;
    public float hookshootSpeed=100f;
    public LayerMask whatIsGrappleables;
    //[SerializeField] bool isEpressed = false;
    [SerializeField] Transform hookShotTransform;
    private float hookshotSize;

    [Header("Camera FOV")]
    public CameraFOV cameraFOV;

    public const float Normal_FOV = 60f;
    public const float HookShot_FOV = 100f;

    [Header("ParticalSystem")]
    public ParticleSystem ParticalSystem;



    private enum State
    {
        Normal,
        HookShotThroon,
        HookShotflyingPlayer,
            
    }
    private void Awake()
    {
        state = State.Normal;
        hookShotTransform.gameObject.SetActive(false);
        ParticalSystem.Stop();
        debugHitPointTransform.SetActive(false);
    }



    void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                PlayerControl();
                HandleHookShootStart();
                break;
            case State.HookShotThroon:
                HandleHookshotThrown();
                PlayerControl();
                break;
            case State.HookShotflyingPlayer:
                HandleHookshotMovement();
                break;
        }
        if (Physics.SphereCast(PlayerCamera.transform.position, 1f, PlayerCamera.transform.forward, out RaycastHit raycastHit, maxGrapableDistance, whatIsGrappleables))
        {
            //Debug.Log("Raycast is Working");
            debugHitPointTransform.transform.position = raycastHit.point;
            debugHitPointTransform.SetActive(true);

        }
        else
        {
            debugHitPointTransform.SetActive(false);
        }
        /*if(velocity.y>-10f && !isGrounded)
        {
            Debug.Log("------FallDamage----");
        }*/
        //Debug.Log(velocity.y);

    }

    private void PlayerControl()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            //controller
            velocity.y = -2f;
            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (TestInputJump() && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        
        
        //velocity += characterVelocityMomentum;
        

        controller.Move(velocity * Time.deltaTime);

        //Dampen momentum
        /*if(characterVelocityMomentum.magnitude>=0f)
        {
            Debug.Log("---------------");
            float momentumDrag = 200f;
            characterVelocityMomentum -= characterVelocityMomentum * momentumDrag * Time.deltaTime;
            if(characterVelocityMomentum.magnitude<.1f)
            {
                Debug.Log("000000000");
                characterVelocityMomentum = Vector3.zero;
            }
        }*/
    }


    private void HandleHookShootStart()
    { 
        if(TestInputSownHookshot())
        {
            //Debug.Log("E is Pressed");
            if(Physics.SphereCast(PlayerCamera.transform.position, 1f,PlayerCamera.transform.forward,out RaycastHit raycastHit, maxGrapableDistance, whatIsGrappleables))
            {
                //Debug.Log("Raycast is Working");
                debugHitPointTransform.transform.position = raycastHit.point;
                hookshotPosition = raycastHit.point;
                hookShotTransform.localScale = Vector3.zero;
                hookshotSize = 0f;
                hookShotTransform.gameObject.SetActive(true);
                //hookShotTransform.localScale = Vector3.zero;
                state = State.HookShotThroon;
                
            }

        }
    }
    private void HandleHookshotThrown()
    {
        hookShotTransform.LookAt(hookshotPosition);
        float hookshootThroowSpeed = hookshootSpeed; //Hook Shot Speed------------120f
        hookShotTransform.LookAt(hookshotPosition);
        hookshotSize += hookshootThroowSpeed * Time.deltaTime;
        hookShotTransform.localScale = new Vector3(1, 1, hookshotSize);

        if(hookshotSize>=Vector3.Distance(transform.position,hookshotPosition))
        {
            state = State.HookShotflyingPlayer;
            cameraFOV.SetCameraFOV(HookShot_FOV);
            ParticalSystem.Play();
        }
    }



    private void RestGravityEffect()
    {
        velocity.y = -2f;
    }

    private void HandleHookshotMovement()
    {

        hookShotTransform.LookAt(hookshotPosition);

        float hookshotSpeedMin = 10f;
        float hookshotSpeedMax = 40f;
        //Debug.Log("HandleHookshotMovement() function");
        Vector3 hookshotDir = (hookshotPosition - transform.position).normalized;

        float hookshotSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), hookshotSpeedMin, hookshotSpeedMax);

        float hookshotspeedMultipler = 2f;

        controller.Move(hookshotDir * hookshotSpeed * hookshotspeedMultipler * Time.deltaTime);

        float reachHookPositionDistance =1.5f;
        if(Vector3.Distance(transform.position,hookshotPosition)< reachHookPositionDistance )
        {
            //Reached
            state = State.Normal;
            RestGravityEffect();
            hookShotTransform.gameObject.SetActive(false);
            cameraFOV.SetCameraFOV(Normal_FOV);
            ParticalSystem.Stop();
        }

        if(TestInputSownHookshot())
        {
            //Cancle Hook Shoot
            state = State.Normal;
            RestGravityEffect();
            hookShotTransform.localScale = Vector3.zero;
            ParticalSystem.Stop();
        }

        /*if(TestInputJump())
        {
            float momntumExtraSpeed = 7f;
            characterVelocityMomentum = hookshotDir * hookshotSpeed * momntumExtraSpeed;
            float jumpSpeed = 40f;
            characterVelocityMomentum += Vector3.up * jumpSpeed;
            state = State.Normal;
            RestGravityEffect();
            hookShotTransform.gameObject.SetActive(false);
        }*/

    }

    private bool TestInputSownHookshot()
    {
        return Input.GetMouseButtonDown(1);
    }
    private bool TestInputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
