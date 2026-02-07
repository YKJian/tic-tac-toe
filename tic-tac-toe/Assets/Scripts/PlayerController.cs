using UnityEngine;
using UnityEngine.EventSystems;

namespace tictactoe
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private EventTrigger m_hitButton;

        private bool m_isDown;

        private void OnEnable()
        {
            var entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;

            var entryUp = new EventTrigger.Entry();
            entryUp.eventID = EventTriggerType.PointerUp;

            entryUp.callback.AddListener(OnPointerUp);
            entryDown.callback.AddListener(OnPointerDown);

            m_hitButton.triggers.Add(entryDown);
            m_hitButton.triggers.Add(entryUp);
        }

        private void Down() => m_isDown = true;

        private void Up() => m_isDown = false;

        private void OnPointerDown(BaseEventData arg0) => Down();

        private void OnPointerUp(BaseEventData arg0) => Up();
    }
}
