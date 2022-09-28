using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkayns.Projects.Vehicles.Drone {
    
    [RequireComponent(typeof(ADroneInput))]
    public class ADroneController : ABaseRigidbody {

        [Header("Control Properties")] 
        [SerializeField] private float m_minMaxPitxh = 30f;
        [SerializeField] private float m_minMaxRoll = 30f;
        [SerializeField] private float m_yawPower = 4f;

        private ADroneInput m_input;
        private List<IEngine> m_engines = new List<IEngine>();

        public void Start() {
            m_input = GetComponent<ADroneInput>();
            m_engines = GetComponentsInChildren<IEngine>().ToList();
        } // Start

        protected override void HandlePhysics() {
            HandleEngine();
            HandleControl();
        } // HandlePhysics

        protected virtual void HandleEngine() {
            foreach (var engine in m_engines) 
                engine.UpdateEngine(m_rb, m_input, (sbyte)m_engines.Count);
            // m_rb.AddForce(Vector3.up * (m_rb.mass * Physics.gravity.magnitude));
        } // HandleEngine
        
        protected virtual void HandleControl() {
            
        } // HandleControl
        
    } // Class ADroneController
    
} // Namespace Arkayns Projects Vehicles