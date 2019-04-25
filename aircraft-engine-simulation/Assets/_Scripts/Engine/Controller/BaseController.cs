using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected List<EngineComponent> components;
    protected bool isListInitialized => components != null;


    protected void GetEngineComponents(string id)
    {
        List<string> componentIdList = EngineComponentManager.GetIds().Where(x => x.Contains(id.ToLower())).ToList();
        components = new List<EngineComponent>();

        foreach (string componentId in componentIdList)
        {
            EngineComponent component = EngineComponentManager.Get(componentId);
            components.Add(component);
        }
    }

    protected void AddEngineComponent(string id)
    {
        if(!isListInitialized) components = new List<EngineComponent>();

        EngineComponent newComponent = EngineComponentManager.Get(id);
        components.Add(newComponent);
    }

    protected void RemoveEngineComponent(string id)
    {
        if (!isListInitialized) return;

        EngineComponent component = components.Find(x => string.Equals(x.Id, id, StringComparison.CurrentCultureIgnoreCase));
        components.Remove(component);
    }

    protected EngineComponent GetEngineComponent(string id)
    {
        if (!isListInitialized) return null;

        EngineComponent component = components.Find(x => string.Equals(x.Id, id, StringComparison.CurrentCultureIgnoreCase));

        if(component == null) throw new WarningException("Engine Component [" + id + "] cannot be found.");

        return component;

    }
}
