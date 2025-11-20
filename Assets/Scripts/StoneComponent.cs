using System;
using UnityEngine;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class StoneComponent : MonoBehaviour
    {
        public event Action<StoneComponent> Hit;
        public event Action<StoneComponent> Missed;

        private Rigidbody m_rigidbody;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }
        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.GetComponent<Stick>())
            {
                Hit?.Invoke(this);
            }

            else
            {
                Missed?.Invoke(this);
            }

        }

        public void AddForce(Vector3 power)
        {
            m_rigidbody.AddForce(power, ForceMode.Impulse);
        }
    }
}
