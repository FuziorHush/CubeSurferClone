using System.Collections;
using UnityEngine;

public class PoolElement : MonoBehaviour
{
    private string _startTag;
    private Transform _parent;

    private void Start()
    {
        _startTag = gameObject.tag;
        _parent = transform.parent;
    }

    public void UnattachAndReturnWithDelay(float delay = 0)//return into pool with delay
    {
        if (delay == 0)
        {
            ReturnIntoPool();
        }
        else if (delay > 0)
        {
            gameObject.transform.SetParent(null);
            gameObject.tag = "ReturningToPool";
            StartCoroutine(DeactivateDelay(delay));
        }
        else
            return;
    }

    public void ReturnIntoPool()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator DeactivateDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.transform.SetParent(_parent);
        gameObject.tag = _startTag;
        ReturnIntoPool();
    }
}
