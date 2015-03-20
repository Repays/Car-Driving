using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour 
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float time = 0;
    private float velocity;



    internal void Start()
    {
        if (!target) target = FindObjectOfType<Car>().transform;
    }

    void LateUpdate()
    {
        if (target)
        {
            transform.position = new Vector3(
                Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity, time),
                Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity, time),
                transform.position.z);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(FollowCamera))]
    class FollowCameraEditor : Editor
    {
        void OnEnable()
        {
            ((FollowCamera)target).Start();
        }
    }
#endif
}
