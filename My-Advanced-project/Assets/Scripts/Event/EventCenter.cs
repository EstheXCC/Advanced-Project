using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter 
{
    private static Dictionary<EventTypem, Delegate> m_EventTable = new Dictionary<EventTypem, Delegate>();
    public static void AddListener(EventTypem EventTypem,CallBack callBack)
    {
        if (!m_EventTable.ContainsKey(EventTypem))
        {
            m_EventTable.Add(EventTypem,null);
        }
        Delegate d = m_EventTable[EventTypem];
        if (d!=null &&d.GetType()!=callBack.GetType())
        {
            throw new Exception("Wrong0");
        }
        m_EventTable[EventTypem] = (CallBack)m_EventTable[EventTypem] + callBack;
    }
    public static void AddListener<T>(EventTypem EventTypem, CallBack<T> callBack)
    {
        if (!m_EventTable.ContainsKey(EventTypem))
        {
            m_EventTable.Add(EventTypem, null);
        }
        Delegate d = m_EventTable[EventTypem];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception("Wrong0");
        }
        m_EventTable[EventTypem] = (CallBack<T>)m_EventTable[EventTypem] + callBack;
    }

    public static void RemoveListener(EventTypem EventTypem,CallBack callBack)
    {

        if (m_EventTable.ContainsKey(EventTypem))
        {
            Delegate d = m_EventTable[EventTypem];
            if (d==null)
            {
                throw new Exception("Wrong1");
            }else if (d.GetType()!=callBack.GetType())
            {
                throw new Exception("Wrong2");
            }
        }else
        {
            throw new Exception("Wrong3");
        }
      m_EventTable[EventTypem]=(CallBack)  m_EventTable[EventTypem] - callBack;
    }
    public static void RemoveListener<T>(EventTypem EventTypem, CallBack<T> callBack)
    {

        if (m_EventTable.ContainsKey(EventTypem))
        {
            Delegate d = m_EventTable[EventTypem];
            if (d == null)
            {
                throw new Exception("Wrong1");
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception("Wrong2");
            }
        }
        else
        {
            throw new Exception("Wrong3");
        }
        m_EventTable[EventTypem] = (CallBack<T>)m_EventTable[EventTypem] - callBack;
    }
    public static void Broadcast(EventTypem EventTypem)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventTypem, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack!=null)
            {
                callBack();
            }
            else
            {
                throw new Exception("Wrong4");
            }
        }
    }
    public static void Broadcast<T>(EventTypem EventTypem,T arg)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(EventTypem, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception("Wrong4");
            }
        }
    }
}
