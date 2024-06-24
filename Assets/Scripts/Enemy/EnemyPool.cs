using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool 
    {
        private EnemyView enemyPrefab;
        private EnemyData enemyData;
       
        private List<PooledEnemies> pooledEnemies = new List<PooledEnemies>();

        public EnemyPool(EnemyView enemyPrefab,EnemyData enemyData)
        {
            this.enemyPrefab = enemyPrefab;
            this.enemyData = enemyData;
        }
        public class PooledEnemies
        {
            public EnemyController Enemy;
            public bool isUsed;
        }

        public EnemyController GetEnemies()
        {
            if(pooledEnemies.Count>0)
            {
                PooledEnemies pooledEnemy = pooledEnemies.Find(item => !item.isUsed);
               if(pooledEnemy!=null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.Enemy;
                }
            }
            return CreateNewPoolEnemies();
        }

        private EnemyController CreateEnemy() => new EnemyController(enemyPrefab, enemyData);

        public EnemyController CreateNewPoolEnemies()
        {
            PooledEnemies enemy = new PooledEnemies();
            enemy.Enemy = CreateEnemy();
            enemy.isUsed = true;
            pooledEnemies.Add(enemy);
            return enemy.Enemy;

        }
        public void ReturnEnemy(EnemyController returnedEnemies)
        {
            PooledEnemies pooledEnemy = pooledEnemies.Find(item => item.Enemy.Equals(returnedEnemies));
            pooledEnemy.isUsed = false;
        }

    }
}