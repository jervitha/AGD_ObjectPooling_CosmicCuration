using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T:class
    {
        private List<PooledItem<T>>pooledItems=new List<PooledItem<T>>();

        protected T GetItem()
        {
            if(pooledItems.Count>0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if(item!=null)
                {
                    item.isUsed = true;
                    return item.Item;
                }

            }
            return CreateNewPooledBullet();
        }
        private T CreateNewPooledBullet()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }
        protected virtual T CreateItem()
        {
            throw new NotImplementedException("child class not having CreateItem()");
        }

    }
 

    public class PooledItem<T>
    {
        public T Item;
        public bool isUsed;

    }
}

