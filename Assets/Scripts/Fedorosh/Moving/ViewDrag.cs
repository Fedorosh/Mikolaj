using UnityEngine;
using System.Collections;

public class ViewDrag : MonoBehaviour
{
    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float z = 0.0f;
    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;

        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
    }

    void LeftMouseDrag()
    {
        float value = Vector3.Distance(current_position,hit_position);

        Debug.Log(value);

        //Vector3 position = Vector3.Lerp(camera_position, hit_position, value);

        //transform.localEulerAngles = position;
    }
}