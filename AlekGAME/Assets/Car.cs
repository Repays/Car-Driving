using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WheelJoint2D))]
[RequireComponent(typeof(WheelJoint2D))]
public class Car : MonoBehaviour
{

    // Inicjalizacja zmiennych 
    [SerializeField]
    protected float speed = 1;

    [SerializeField]
    protected WheelJoint2D[] wheelJoints = new WheelJoint2D[] { };

    [SerializeField]
    protected Wheel[] wheelScripts = new Wheel[] { };

    private JointMotor2D motor;

    private float velocity;


    // Funkcja sprawdzająca czy oba koła znajdują się w powietrzu
    public bool IsFlying
    {
        get
        {
            bool isFlying = true;
            foreach (Wheel wheel in wheelScripts)
                isFlying &= wheel.isFlying;
            return isFlying;
        }
    }

    
    protected internal void Start()
    {
        if (wheelJoints.Length == 0)
            wheelJoints = GetComponentsInChildren<WheelJoint2D>(); // Zwraca typ komponentów obiektu lub jego pochodnych

        if (wheelScripts.Length == 0)
            wheelScripts = GetComponentsInChildren<Wheel>();

        if (wheelJoints.Length > 0)
        {
            motor = wheelJoints[0].motor;
            setwheelJoints(motor);
        }
    }

    // Funkcja ustawiająca nowe parametry silnika dla każdego z kół
    private void setwheelJoints(JointMotor2D _motor)
    {
        foreach (WheelJoint2D w in wheelJoints)
            w.motor = _motor;
    }


    // Funckja, która pozwala na poruszanie się zarówno w powietrzu jak i w locie,
    protected virtual void FixedUpdate()
    {
        if (!IsFlying)
        {
            motor.motorSpeed = -Input.GetAxis("Horizontal") * speed; // by strzałka w prawo odpowiadała za ruch do przodu
            setwheelJoints(motor);
        }
        else
        {
            Vector3 rot = transform.eulerAngles;
            rot.z = rot.z + Input.GetAxis("Horizontal") * Mathf.Sqrt(speed / 50);
            transform.eulerAngles = rot;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Car))]
    class CarEditor : Editor
    {
        protected virtual void OnEnable()
        {
            ((Car)target).Start();
        }
    }
#endif
}
