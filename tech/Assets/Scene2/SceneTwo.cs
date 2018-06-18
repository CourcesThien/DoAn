using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTwo : MonoSingleton<SceneTwo>
{
    public Transform startPosition;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Vector3 pos = startPosition.position;
        pos.z = 0;
        PlayerController.Instance.transform.position = pos;
    }
}
