using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RPG;

public class SceneOne : MonoSingleton<SceneOne>
{
    public Collider2D[] wallBlock;

    public Collider2D[] boxKeyBox;

    public Transform startPosition;

    public BoxKey[] allBoxKey;

    int currKeyDone = 0;
    private int KEY_DONE = 2;

    public GameObject objStartPoint;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        try
        {
            
            Vector3 pos = startPosition.position;
            pos.z = 0;

            foreach (var item in allBoxKey)
            {
                item.onDone += OnDoneKeyOne;
            }
            objStartPoint.SetActive(false);

            PlayerController.Instance.transform.position = pos;
            Seed.Instance.transform.position = pos;
            CameraFollow.Instance.transform.position = pos;
          
        }
        catch
        {
            
        }
    }

    private void OnDoneKeyOne()
    {
        currKeyDone++;
        if (currKeyDone >= 2)
        {
            objStartPoint.SetActive(true);
        }
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
