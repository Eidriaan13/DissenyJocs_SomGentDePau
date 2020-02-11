using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    public bool isButtonPressed = false;

    public bool isDown = false;
    public bool canPlaceHere = false;

    public int m_MouseShootButton = 0;
    public KeyCode m_RotationLeftKey = KeyCode.Z;
    public KeyCode m_RotationRightKey = KeyCode.X;

    public float rotationalSpeed = 90;

    public Camera megamapCamera;
    public GameObject minimapIcon;

    public Material greenMaterial;
    public Material redMaterial;
    public Material normalMaterial;

    public Transform origin;

    public GameObject container;

    // Start is called before the first frame update
    void Start()
    {
        minimapIcon.GetComponent<MeshRenderer>().material = greenMaterial;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        origin = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isButtonPressed)
        {
            if (Input.GetKeyDown(m_RotationLeftKey))
            {
                transform.Rotate(new Vector3(0, rotationalSpeed, 0));

            }
            else if (Input.GetKeyDown(m_RotationRightKey))
            {
                transform.Rotate(new Vector3(0, rotationalSpeed, 0));

            }

            float l_MouseAxisY = Input.GetAxis("Mouse Y");
            float l_MouseAxisX = Input.GetAxis("Mouse X");

            Vector3 worldPos = megamapCamera.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(worldPos.x, transform.position.y, worldPos.z);

            if (Input.GetMouseButton(m_MouseShootButton))
            {
                if (canPlaceHere)
                {
                    Instantiate(container, transform.position, transform.rotation);
                    isButtonPressed = false;
                }
                else
                {
                    isButtonPressed = false;
                    
                }
            }

        }
        else
        {
            minimapIcon.GetComponent<MeshRenderer>().material = normalMaterial;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag != "Terra")
        {
            canPlaceHere = false;
            minimapIcon.GetComponent<MeshRenderer>().material = redMaterial;

        }



    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag != "Terra")
        {
             canPlaceHere = true;
        minimapIcon.GetComponent<MeshRenderer>().material = greenMaterial;
        }
    }

    public void IsButtonPressed(bool a)
    {
        isButtonPressed = a;
        gameObject.SetActive(true);
    }
}
