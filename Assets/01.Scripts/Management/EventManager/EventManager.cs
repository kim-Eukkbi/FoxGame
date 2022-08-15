using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager<T,T1>
{
    // �̺�Ʈ �Ŵ��� v.3
    // ���� �̺�Ʈ�� ������ ���� �� ����
    // ���� Ű������ ���ڿ� ���� �������� ��� �� �� ����
    // Action���� ������
    // ��, �� �ٲ� ������ ����� �ش� �̺�Ʈ �Ŵ����� �� �ʱ�ȭ ���Ѿ���

    private static Dictionary<T, UnityAction<T1>> events = new Dictionary<T, UnityAction<T1>>();

    public static void AddEvent(T key, UnityAction<T1> action)    // Ư�� �̸��� �̺�Ʈ�� �߰��ϰ� �Լ��� ���� �߰�
    {
        if (!events.ContainsKey(key))
        {
            events.Add(key, (val) => { });
        }

        events[key] += action;
    }

    public static void Invoke(T key, T1 value)
    {
        if (events.ContainsKey(key))
        {
            events[key].Invoke(value);
        }
    }

    public static void RemoveEvent(T key, UnityAction<T1> action) // Ư�� �̸��� �̺�Ʈ �ȿ� �ִ� �Լ��� ����
    {
        if (events.ContainsKey(key))
        {
            events[key] -= action;
        }
    }

    public static void RemoveAllEvents(T key)            // Ư�� �̸��� �̺�Ʈ�� �ʱ�ȭ
    {
        if (events.ContainsKey(key))
        {
            events[key] = (val) => { };
        }
    }

    public static void RemoveAllEvents()                 // ��ųʸ� �ȿ� �ִ� �̺�Ʈ�� �ϴ� �ʱ�ȭ
    {
        List<T> keys = new List<T>();

        foreach (var key in events.Keys)
        {
            keys.Add(key);
        }

        for (int i = 0; i < keys.Count; i++)
        {
            events[keys[i]] = (val) => { };
        }
    }

    public static void PrintKey()
    {
        Debug.Log($"===== {typeof(T).ToString()} �̺�Ʈ �Ŵ��� ��� =====");

        foreach (var key in events.Keys)
        {
            Debug.Log(key.ToString());
        }
    }
}
