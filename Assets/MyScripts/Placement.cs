using UnityEngine;

public class Placement : MonoBehaviour
{

    [SerializeField] private GameObject slot1 = null;
    [SerializeField] private GameObject slot2 = null;
    [SerializeField] private GameObject slot3 = null;
    [SerializeField] private GameObject slot4 = null;

    [SerializeField] private GameObject objectPrefab;

    [SerializeField] private KeyCode slot1H = KeyCode.Alpha1;
    [SerializeField] private KeyCode slot2H = KeyCode.Alpha2;
    [SerializeField] private KeyCode slot3H = KeyCode.Alpha3;
    [SerializeField] private KeyCode slot4H = KeyCode.Alpha4;

    [SerializeField] private KeyCode newObjectHotkey;

    private GameObject currentObject;

    private float mouseWheelRotation;

    public calculation hesap;

    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            newObjectHotkey = slot1H;
            objectPrefab = slot1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            newObjectHotkey = slot2H;
            objectPrefab = slot2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            newObjectHotkey = slot3H;
            objectPrefab = slot3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            newObjectHotkey = slot4H;
            objectPrefab = slot4;
        }

        objectHotkey();

        if (currentObject != null)
        {
            MoveObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
        }
    }

    public void objectHotkey()
    {
        if (Input.GetKeyDown(newObjectHotkey))
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            else
            {
                currentObject = Instantiate(objectPrefab);
            }
        }
    }

    public void MoveObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentObject.transform.position = hitInfo.point;
            currentObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void RotateFromMouseWheel()
    {
        //Debug.Log(Input.mouseScrollDelta);
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (newObjectHotkey == KeyCode.Alpha1)
            {
                hesap.CalculateValues1();
            }
            if (newObjectHotkey == KeyCode.Alpha2)
            {
                hesap.CalculateValues2();
            }
            currentObject = null;
        }
    }
}