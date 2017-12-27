using System;
using UnityEngine;

namespace Finegamedesign.Utils
{
    [Serializable]
    public sealed class PauseModel
    {
        private const string kNoneState = "none";
        private const string kBeginState = "begin";
        private const string kEndState = "end";

        public static event Action<string> onStateChanged;

        private string m_State = kNoneState;

        private bool m_IsPaused;

        public bool isPaused
        {
            get
            {
                return m_IsPaused;
            }
            set
            {
                if (value)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
                m_IsPaused = value;
            }
        }

        public string state
        {
            get
            {
                return m_State;
            }
            set
            {
                if (m_State == value)
                {
                    return;
                }
                m_State = value;
                if (onStateChanged == null)
                {
                    return;
                }
                onStateChanged(value);
            }
        }

        [SerializeField]
        [Tooltip("Scales time to zero when paused and back to one after resumed.")]
        private bool m_scaleTime = false;

        public bool scaleTime
        {
            get { return m_scaleTime; }
            set { m_scaleTime = value; }
        }

        public void Pause()
        {
            if (m_IsPaused)
            {
                return;
            }
            m_IsPaused = true;
            if (m_scaleTime)
            {
                Time.timeScale = 0.0f;
            }
            state = kBeginState;
        }

        public void Resume()
        {
            if (!m_IsPaused)
            {
                return;
            }
            m_IsPaused = false;
            if (m_scaleTime)
            {
                Time.timeScale = 1.0f;
            }
            state = kEndState;
        }
    }
}
