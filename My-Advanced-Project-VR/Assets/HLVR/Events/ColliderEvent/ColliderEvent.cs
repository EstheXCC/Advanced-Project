using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HLVR.Event;
public class ColliderEvent : MonoBehaviour
{
    public bool m_UseTag;
    public string m_Tag;
    public bool m_RunCloseThe;
    public InteractionEvent OnCollisionEnterEvent;
    public InteractionEvent OnCollisionStayEvent;
    public InteractionEvent OnCollisionExitEvent;
    public InteractionEvent OnTriggerEnterEvent;
    public InteractionEvent OnTriggerStayEvent;
    public InteractionEvent OnTriggerExitEvent;
    //public DrawType drawType;
    //public Color m_DrawColor = Color.green;
    //BoxCollider col;
    //SphereCollider scl;
    //public enum DrawType 
    //{
    //  CubeCollider,
    //  SphereCollider
    //}
    //private void Reset()
    //{
    //    switch (drawType)
    //    {
    //        case DrawType.CubeCollider:col = GetComponent<BoxCollider>();break;
    //        case DrawType.SphereCollider: scl = GetComponent<SphereCollider>(); break;
    //    }

    //}
    //private void OnDrawGizmosSelected()
    //{
    //    if (col != null)
    //    {
    //        Gizmos.color = m_DrawColor;
    //        Gizmos.DrawCube(col.transform.position, col.size);
    //    }
    //    else if (scl != null)
    //    {
    //        Gizmos.color = m_DrawColor;
    //        Gizmos.DrawSphere(scl.transform.position,scl.radius);
    //    }
    //    else 
    //    {
    //        Debug.LogWarning("当前碰撞物体没有指定的碰撞盒");
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (OnCollisionEnterEvent != null && !m_UseTag)
        {
            OnCollisionEnterEvent.Invoke();
            if(m_RunCloseThe)
             this.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag== m_Tag && m_UseTag)
        {
            if (OnCollisionEnterEvent != null) {
                OnCollisionEnterEvent.Invoke();
                if (m_RunCloseThe)
                 this.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionStay(Collision collision) 
    {
        if (OnCollisionStayEvent != null && !m_UseTag)
            OnCollisionStayEvent.Invoke();
        else if (collision.gameObject.tag == m_Tag && m_UseTag) 
        {
            if (OnCollisionStayEvent != null)
                OnCollisionStayEvent.Invoke();
        }

        
    }


    private void OnCollisionExit(Collision collision) 
    {
        if (OnCollisionExitEvent != null && !m_UseTag)
            OnCollisionExitEvent.Invoke();
        else if (collision.gameObject.tag == m_Tag && m_UseTag) {
            if (OnCollisionExitEvent != null )
                OnCollisionExitEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (!m_UseTag)
            OnTriggerEnterEvent?.Invoke();
        else if (other.gameObject.tag == m_Tag && m_UseTag) 
        {
          
                OnTriggerEnterEvent?.Invoke();
            if (m_RunCloseThe)
                this.gameObject.SetActive(false);

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if ( !m_UseTag)
            OnTriggerStayEvent?.Invoke();
        else if (other.gameObject.tag == m_Tag && m_UseTag) 
        {
            
                OnTriggerStayEvent?.Invoke();
            if (m_RunCloseThe)
                this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (OnTriggerExitEvent != null && !m_UseTag)
            OnTriggerExitEvent.Invoke();
        else if (other.gameObject.tag == m_Tag && m_UseTag)
        {
            
                OnTriggerExitEvent?.Invoke();
            if (m_RunCloseThe)
                this.gameObject.SetActive(false);
        }
    }
}
