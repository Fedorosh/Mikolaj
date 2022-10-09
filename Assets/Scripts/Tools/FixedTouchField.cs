using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 TouchDist { get; set; }
    public bool Pressed { get; set; }

    private Vector2 pointerOld;
    protected int pointerId;

    void Start()
    {

    }

    void Update()
    {
        if (Pressed)
        {
#if UNITY_EDITOR
            if (pointerId >= 0 && pointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[pointerId].position - pointerOld;
                pointerOld = Input.touches[pointerId].position;
            }
            else
            {
                TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                pointerOld = Input.mousePosition;
            }
#else
            if (pointerId >= 0 && pointerId < Input.touches.Length)
                TouchDist = Input.touches[pointerId].deltaPosition;
            else TouchDist = Input.GetTouch(0).deltaPosition;
#endif
        }
        else
        {
            TouchDist = new Vector2();
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        pointerId = eventData.pointerId;
        pointerOld = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

}