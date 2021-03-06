using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Finegamedesign.Utils
{
    public static class ClickPoint
    {
        public static event Action<Vector3> onClick;
        public static event Action<float, float> onClickXY;
        public static event Action<float, float> onViewportXY;
        public static event Action<float, float> onAxisXY;

        public static event Action<Vector3> onCollisionEnter;
        public static event Action<Vector2> onCollisionEnter2D;

        private static Vector2 s_OverlapPoint = new Vector2();

        private static Vector3 s_RaycastHit = new Vector3();

        private static Vector3 s_Click = new Vector3();
        private static Vector3 s_Viewport = new Vector3();
        private static Vector2 s_Axis = new Vector2();

        private static float s_UpdateTime = -1.0f;

        private static bool s_IsVerbose = true;

        private static bool Raycast()
        {
            RaycastHit hit;
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                return false;
            }
            s_RaycastHit = hit.point;
            if (onCollisionEnter != null)
            {
                onCollisionEnter(s_RaycastHit);
            }
            if (s_IsVerbose)
            {
                Debug.Log("ClickPoint.RayCast: " + s_RaycastHit);
            }
            return true;
        }

        private static bool OverlapPoint()
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            s_OverlapPoint.x = point.x;
            s_OverlapPoint.y = point.y;
            if (Physics2D.OverlapPoint(s_OverlapPoint) == null)
            {
                return false;
            }
            if (onCollisionEnter2D != null)
            {
                onCollisionEnter2D(s_OverlapPoint);
            }
            if (s_IsVerbose)
            {
                Debug.Log("ClickPoint.OverlapPoint: " + s_OverlapPoint);
            }
            return true;
        }

        private static bool Viewport()
        {
            s_Viewport = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (onViewportXY != null)
            {
                onViewportXY(s_Viewport.x, s_Viewport.y);
            }
            if (onAxisXY != null)
            {
                s_Axis.x = s_Viewport.x - 0.5f;
                s_Axis.y = s_Viewport.y - 0.5f;
                s_Axis.Normalize();
                onAxisXY(s_Axis.x, s_Axis.y);
            }
            if (s_IsVerbose)
            {
                Debug.Log("ClickPoint.Viewport: " + s_Viewport);
            }
            return true;
        }

        private static bool Screen()
        {
            s_Click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (onClick != null)
            {
                onClick(s_Click);
            }
            if (onClickXY != null)
            {
                onClickXY(s_Click.x, s_Click.y);
            }
            if (s_IsVerbose)
            {
                Debug.Log("ClickPoint.Screen: " + s_Click);
            }
            return true;
        }

        // Caches time to ignore multiple calls per frame.
        //
        // Ignores if over UI object.
        // Otherwise, a tap on a button is also reacted as a tap in viewport.
        // For example, in Deadly Diver, a viewport tap moves the diver.
        public static void Update()
        {
            if (s_UpdateTime == Time.time)
            {
                return;
            }
            s_UpdateTime = Time.time;
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Raycast();
            OverlapPoint();
            Screen();
            Viewport();
        }
    }
}
