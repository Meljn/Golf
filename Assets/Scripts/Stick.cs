using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField][Min(0)] private float m_power = 250;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngleZ = -30;
        [SerializeField] private float m_maxAngleZ = 30;
        [SerializeField][Min(0)] private float m_speed;
        [SerializeField] private GameObject m_particle;

        private Vector3 m_direction;
        private Vector3 m_lastPointPosition;
        private bool m_isDown;
        private void FixedUpdate()
        {
            var angles = transform.localEulerAngles;
            if (m_isDown)
            {
                angles.z = Rotate(angles.z, m_minAngleZ);
            }
            else
            {
                angles.z = Rotate(angles.z, m_maxAngleZ);
            }

            transform.localEulerAngles = angles;

            m_direction = (m_point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = m_point.position;
        }
        public void Down() => m_isDown = true;
        public void Up() => m_isDown = false;

        private float Rotate(float angleZ, float target)
        {
            return Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.TryGetComponent<StoneComponent>(out var stone))
            {
                stone.AddForce(m_power * m_direction);
                Instantiate(m_particle, stone.transform.position, stone.transform.rotation);
            }
        }


    }
}