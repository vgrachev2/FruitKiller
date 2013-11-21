using Assets.Scripts.Helpers;
using FruitKiller;
using UnityEditor;
using UnityEngine;
using System.Collections;


    [CustomEditor(typeof(Fruit))]
    public class MyTypeEditor : Editor
    {
        Fruit m_Instance;
        PropertyField[] m_fields;


        public void OnEnable()
        {
            m_Instance = target as Fruit;
            m_fields = ExposeProperties.GetProperties(m_Instance);
        }

        public override void OnInspectorGUI()
        {

            if (m_Instance == null)
                return;

            this.DrawDefaultInspector();

            ExposeProperties.Expose(m_fields);

        }
    }

