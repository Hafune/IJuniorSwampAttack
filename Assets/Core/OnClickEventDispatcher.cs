using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnClickEventDispatcher : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent<PointerEventData> onClick;

    public void OnPointerClick(PointerEventData eventData) => onClick?.Invoke(eventData);
}