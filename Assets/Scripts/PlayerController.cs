using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Stick m_stick;

        [SerializeField] private EventTrigger m_button;

        private bool m_isDown;

        private void Start()
        {
            var entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;
            
            var entryUp = new EventTrigger.Entry();
            entryUp.eventID = EventTriggerType.PointerUp;
            
            entryUp.callback.AddListener(OnPointerUp);
            entryDown.callback.AddListener(OnPointerDown);
            
            m_button.triggers.Add(entryDown);
            m_button.triggers.Add(entryUp);
        }

        private void OnPointerDown(BaseEventData arg0) => Down();

        private void OnPointerUp(BaseEventData arg0) => Up();

        private void Update()
        {
            if (m_isDown)
            {
                m_stick.Down();
            }
            else
            {
                m_stick.Up();
            }
        }

        private void Down()
        {
            m_isDown = true;
        }

        private void Up()
        {
            m_isDown = false;
        }
    }
}