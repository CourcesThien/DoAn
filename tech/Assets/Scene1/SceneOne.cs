using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOne : MonoSingleton<SceneOne>
{
    public Collider2D[] wallBlock;

    public Collider2D[] boxKeyBox;

    public Transform startPosition;


    protected override void Awake()
    {
        base.Awake();
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Vector3 pos = startPosition.position;
        pos.z = 0;
        PlayerController.Instance.transform.position = pos;
    }

    public void SetActiveWallBlock(bool isActive)
    {
        foreach (var item in wallBlock)
        {
            item.enabled = isActive;
        }
    }

    public void SetActiveBoxKey(bool isActive)
    {
        foreach (var item in boxKeyBox)
        {
            item.enabled = isActive;
        }
    }
}
