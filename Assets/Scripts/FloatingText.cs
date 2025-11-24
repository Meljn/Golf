using UnityEngine;
using TMPro;

namespace Golf
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private float m_lifetime = 20f;
        [SerializeField] private float m_speed = 1f;
        [SerializeField] private Vector3 m_randomOffset = new Vector3(0.5f, 0.5f, 0f);
        [SerializeField] private float m_fontSize = 16f;
        [SerializeField] private Color m_textColor = Color.orange;
        [SerializeField] private FontWeight m_fontWeight = FontWeight.Bold;

        private TextMeshPro m_text;
        private float m_timer;
        private Camera m_camera;

        private void Awake()
        {
            m_text = GetComponent<TextMeshPro>();
            m_camera = Camera.main;

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        public void Initialize(string text)
        {
            m_text.text = text;
            m_text.fontWeight = m_fontWeight;
            m_text.fontSize = m_fontSize;
            m_text.color = m_textColor;
            m_text.horizontalAlignment = HorizontalAlignmentOptions.Center;
            m_text.verticalAlignment = VerticalAlignmentOptions.Middle;

            transform.position += new Vector3(
                Random.Range(-m_randomOffset.x, m_randomOffset.x),
                Random.Range(-m_randomOffset.y, m_randomOffset.y),
                Random.Range(-m_randomOffset.z, m_randomOffset.z)
            );
        }

        private void Update()
        {
            m_timer += Time.deltaTime;

            transform.position += Vector3.up * m_speed * Time.deltaTime;

            if (m_camera != null)
            {
                float cameraYRotation = m_camera.transform.eulerAngles.y;
                transform.rotation = Quaternion.Euler(0, cameraYRotation, 0);
            }

            m_text.alpha = 1f - (m_timer / m_lifetime);

            if (m_timer >= m_lifetime)
            {
                Destroy(gameObject);
            }
        }
    }
}