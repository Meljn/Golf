using System;
using Golf.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class StoneComponent : MonoBehaviour
    {
        public event Action<StoneComponent> Hit;
        public event Action<StoneComponent> Missed;

        [SerializeField] private StoneData[] m_data;

        private Rigidbody m_rigidbody;

        public int score { get; private set; }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            score = m_data[Random.Range(0, m_data.Length)].score;
        }
        private void OnCollisionEnter(Collision collision)
        {


            if (collision.gameObject.GetComponent<Stick>())
            {
                if (m_data[Random.Range(0, m_data.Length)].particle != null)
                {
                    Instantiate(m_data[Random.Range(0, m_data.Length)].particle, transform.position, transform.rotation);
                }

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
