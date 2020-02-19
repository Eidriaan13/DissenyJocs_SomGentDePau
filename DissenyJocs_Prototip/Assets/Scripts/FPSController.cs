using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

    public GameObject m_GameController;

    //Moviment Camera
    public Transform m_PitchControllerTransform;
    float m_Yaw;
    float m_Pitch;
    public float m_YawRotationalSpeed = 360.0f;
    public float m_PitchRotationalSpeed = 180.0f;
    public float m_MinPitch = -80.0f;
    public float m_MaxPitch = 50.0f;
    public bool m_InvertedYaw = false;
    public bool m_InvertedPitch = true;

    //Moviment player
    CharacterController m_CharacterController;
    public float m_Speed = 10.0f;
    public KeyCode m_LeftKeyCode = KeyCode.A;
    public KeyCode m_RightKeyCode = KeyCode.D;
    public KeyCode m_UpKeyCode = KeyCode.W;
    public KeyCode m_DownKeyCode = KeyCode.S;
    public KeyCode m_RunKeyCode = KeyCode.LeftShift;
    public Vector3 l_Movement;
    public float m_FastSpeedMultiplier = 1.2f;

    //Salt i gravetat i correr
    float m_VerticalSpeed = 0.0f;
    bool m_OnGround = false;
    public KeyCode m_JumpKeyCode = KeyCode.Space;
    public float m_JumpSpeed = 10.0f;

    //Disparar
    public int m_MouseShootButton = 0;
    public KeyCode m_reloadKeyCode = KeyCode.R;

    //Bloquejos
    public KeyCode m_DebugLockAngleKeyCode = KeyCode.I;
    public KeyCode m_DebugLockKeyCode = KeyCode.O;

    
    public KeyCode m_activateCode = KeyCode.F;

    //Important ITEMS!!!!
    public Inventory inventory;
    public Inventory.ItemType selectedItem = Inventory.ItemType.Pedra;

    //Important ThrowSimulation
    private ThrowSimulation throwSimulationS;
    public GameObject pedra;
    public GameObject ampolla;
    public GameObject adoqui;
    public GameObject molotov;
    private GameObject objectToThrow;



    void Awake()
    {
       
        m_Yaw = transform.rotation.eulerAngles.y;
        m_Pitch = m_PitchControllerTransform.localRotation.eulerAngles.x;

        m_CharacterController = GetComponent<CharacterController>();
        throwSimulationS = GetComponent<ThrowSimulation>();

       
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

        //Moviment camera
        float l_MouseAxisY = Input.GetAxis("Mouse Y");
        float l_MouseAxisX = Input.GetAxis("Mouse X");

        if (m_InvertedPitch)
        {
            m_Pitch -= l_MouseAxisY * m_PitchRotationalSpeed * Time.deltaTime;
            m_Pitch = Mathf.Clamp(m_Pitch, m_MinPitch, m_MaxPitch);
        }
        else
        {
            m_Pitch += l_MouseAxisY * m_PitchRotationalSpeed * Time.deltaTime;
            m_Pitch = Mathf.Clamp(m_Pitch, m_MinPitch, m_MaxPitch);
        }

        if (m_InvertedYaw)
        {
            m_Yaw -= l_MouseAxisX * m_YawRotationalSpeed * Time.deltaTime;
        }
        else
        {
            m_Yaw += l_MouseAxisX * m_YawRotationalSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(0.0f, m_Yaw, 0.0f);
        m_PitchControllerTransform.localRotation = Quaternion.Euler(m_Pitch, 0.0f, 0.0f);

        //Moviment player
        float l_YawInRadians = m_Yaw * Mathf.Deg2Rad;
        float l_Yaw90InRadians = (m_Yaw + 90.0f) * Mathf.Deg2Rad;

        Vector3 l_Forward = new Vector3(Mathf.Sin( l_YawInRadians), 0.0f, Mathf.Cos(l_YawInRadians));
        Vector3 l_Right = new Vector3(Mathf.Sin(l_Yaw90InRadians), 0.0f, Mathf.Cos(l_Yaw90InRadians));

        if (Input.GetKey(m_UpKeyCode))
            l_Movement += l_Forward;
        else if (Input.GetKey(m_DownKeyCode))
            l_Movement -= l_Forward;
        
        
        if (Input.GetKey(m_RightKeyCode))
            l_Movement += l_Right;
        else if (Input.GetKey(m_LeftKeyCode))
            l_Movement -= l_Right;

        if (!Input.GetKey(m_UpKeyCode) && !Input.GetKey(m_DownKeyCode) && !Input.GetKey(m_RightKeyCode) && !Input.GetKey(m_LeftKeyCode))
        {
            l_Movement = new Vector3(0, 0, 0);
        }
        

        l_Movement.Normalize();
        //l_Movement = l_Movement * Time.deltaTime * m_Speed;

        float l_SpeedMultiplier = 1.0f;
        if (Input.GetKey(m_RunKeyCode))
            l_SpeedMultiplier = m_FastSpeedMultiplier;

        l_Movement *= Time.deltaTime * m_Speed * l_SpeedMultiplier;

        if (l_Movement.magnitude > 0)
        {
            if (Input.GetKey(m_RunKeyCode))
            {
                
                
            }
            else
            {
                
            }
            
        }
        
        //Salt i gravetat 
        m_VerticalSpeed += Physics.gravity.y * Time.deltaTime;
        l_Movement.y = m_VerticalSpeed * Time.deltaTime;
        CollisionFlags l_CollisionFlags = m_CharacterController.Move(l_Movement);
        if ((l_CollisionFlags & CollisionFlags.Below) != 0)
        {
            m_OnGround = true;
            m_VerticalSpeed = 0.0f;
        }
        else
            m_OnGround = false;
        if ((l_CollisionFlags & CollisionFlags.Above) != 0 && m_VerticalSpeed > 0.0f)
            m_VerticalSpeed = 0.0f;

        l_CollisionFlags = m_CharacterController.Move(l_Movement);
        if (m_OnGround && Input.GetKeyDown(m_JumpKeyCode))
            m_VerticalSpeed = m_JumpSpeed;

        //Utilitar Item!!!

        selectedItem = inventory.selectedItem;

        if ( Input.GetMouseButtonDown(m_MouseShootButton))
        {
            switch (selectedItem)
            {
                case Inventory.ItemType.Pedra:
                    if (inventory.inventoryItem1_Qty > 0)
                    {
                        inventory.ConsumeItem(Inventory.ItemType.Pedra);
                        objectToThrow = Instantiate(pedra, transform.position, transform.rotation);
                        throwSimulationS.Projectile = objectToThrow.transform;
                        throwSimulationS.StartCorroutineCall();

                    }
                    break;
                case Inventory.ItemType.Adoqui:
                    if (inventory.inventoryItem2_Qty > 0)
                    {
                        inventory.ConsumeItem(Inventory.ItemType.Adoqui);
                        objectToThrow = Instantiate(adoqui, transform.position, transform.rotation);
                        throwSimulationS.Projectile = objectToThrow.transform;
                        throwSimulationS.StartCorroutineCall();
                    }
                    break;
                case Inventory.ItemType.Ampolla:
                    if (inventory.inventoryItem3_Qty > 0)
                    {
                        inventory.ConsumeItem(Inventory.ItemType.Ampolla);
                        objectToThrow = Instantiate(ampolla, transform.position, transform.rotation);
                        throwSimulationS.Projectile = objectToThrow.transform;
                        throwSimulationS.StartCorroutineCall();
                    }
                    break;
                case Inventory.ItemType.Molotov:
                    if (inventory.inventoryItem4_Qty > 0)
                    {
                        inventory.ConsumeItem(Inventory.ItemType.Molotov);
                        objectToThrow = Instantiate(molotov, transform.position, transform.rotation);
                        throwSimulationS.Projectile = objectToThrow.transform;
                        throwSimulationS.StartCorroutineCall();
                    }
                    break;
                default:
                    break;
            }
        }
       

    }

    

    
}
