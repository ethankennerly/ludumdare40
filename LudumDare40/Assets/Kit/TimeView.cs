using UnityEngine;

namespace Finegamedesign.Utils
{
    public sealed class TimeView : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 8)]
        private float m_TimeScale = 1.0f;

        private void Start()
        {
            m_TimeScale = Time.timeScale;
        }

        private void OnValidate()
        {
            if (m_TimeScale == Time.timeScale)
            {
                return;
            }
            Time.timeScale = m_TimeScale;
            m_TimeScale = Time.timeScale;
        }

        private void Update()
        {
            if (m_TimeScale == Time.timeScale)
            {
                return;
            }
            m_TimeScale = Time.timeScale;
        }
    }
}
