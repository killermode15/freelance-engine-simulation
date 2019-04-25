using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EngineComponentManager
{
    private static Dictionary<string, EngineComponent> components;
    private static bool isInitialized => components != null;

    public static void InitializeManager()
    {
        if (isInitialized) return;

        List<EngineComponent> foundComponents = GameObject.FindObjectsOfType<EngineComponent>().ToList();

        components = new Dictionary<string, EngineComponent>();

        foreach (EngineComponent component in foundComponents)
        {
            components.Add(component.Id.ToLower(), component);
        }

        SceneManager.sceneUnloaded += UninitializeManager;
        SceneManager.sceneLoaded += UninitializeManager;
    }

    public static EngineComponent Get(string id)
    {
        InitializeManager();

        if(components.TryGetValue(id.ToLower(), out EngineComponent component))
            return component;
        else
        {
            Debug.LogWarning("Component [" + id + "] cannot be found. Check the ID.");
            return null;
        }
    }

    public static List<string> GetIds()
    {
        InitializeManager();

        return components.Keys.ToList();
    }

    public static List<EngineComponent> GetComponents()
    {
        InitializeManager();

        return components.Values.ToList();
    }

    private static void UninitializeManager(Scene scene)
    {
        if (!isInitialized) return;

        components = null;
    }

    private static void UninitializeManager(Scene scene, LoadSceneMode mode)
    {
        if (!isInitialized) return;

        components = null;
    }
}
