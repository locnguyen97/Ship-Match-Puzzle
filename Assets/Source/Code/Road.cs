  using System.Collections;
using System.Collections.Generic;
  using DG.Tweening;
  using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Transform parentListSlot;
    public List<Transform> listSlot;
    public string type;
    void Start()
    {
        foreach (Transform tr in parentListSlot)
        {
            listSlot.Add(tr);
        }
        
    }

    public void MoveToSpawn()
    {
        transform.DOMoveX(0.2f, 0.5f).OnComplete(
            () =>
            {
                GameManager.Instance.EnableDrag();
            });
    }

    public void RemoveSlot()
    {
        listSlot.RemoveAt(0);
        if (listSlot.Count == 0)
        {
            var particleVFXs = GameManager.Instance.particleVFXs;
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
            transform.DOMoveX(transform.position.x + 500, 0.5f).OnComplete(
                () =>
                {
                    GameManager.Instance.GetCurLevel().NextRoad();
                    Destroy(gameObject);
                });
        }
        else
        {
            GameManager.Instance.EnableDrag();
        }
    }
}
