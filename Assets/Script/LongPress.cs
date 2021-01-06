using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField]
    [Tooltip("How long must pointer be down on this object to trigger a long press")]
    private float holdTime = 1f;

    public GameObject test;
 
    //private bool held = false;
    //public UnityEvent onClick = new UnityEvent();
 
    public UnityEvent onLongPress = new UnityEvent();
 
    public void OnPointerDown(PointerEventData eventData)
    {
        //held = false;
        Invoke("OnLongPress", holdTime);
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
 
        //if (!held)
        //    onClick.Invoke();
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        CancelInvoke("OnLongPress");
    }
 
     public void OnLongPress()
    {
      Debug.Log("ma apesi");
      DestroyImmediate(test.GetComponent<EventTrigger>());
        onLongPress.Invoke();
    }
}