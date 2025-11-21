using System;
using Golf.Data;
using UnityEngine;
using Random = System.Random;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class StoneComponent : MonoBehaviour
    {
        public event Action<StoneComponent> Hit;
        public event Action<StoneComponent> Missed;

        [SerializeField] private StoneData[] m_data;
        private Rigidbody m_rigidbody;
        private StoneData m_currentData;

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            m_currentData = m_data[Random.Range(0, m_data.Length)];
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
