using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolTool : MonoBehaviour
{
    public GameObject objectPrefa;
    private ObjectPool<GameObject> pool;
    private void Start()
    {
        //初始化对象池
        pool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(objectPrefa,transform),
            actionOnGet: (obj) => obj.SetActive(true),
            actionOnRelease: (obj) => obj.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: 10,
            maxSize: 10
        );
        PreFillPool(3);
    }

    private void PreFillPool(int count)  //预先生成一些
    {
        var preFillArray=new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            preFillArray[i]=pool.Get();
        }
        foreach (var item in preFillArray)
        {
            pool.Release(item);

        }

    }
}
