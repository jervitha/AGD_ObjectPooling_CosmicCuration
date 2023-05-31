using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] public Transform canonTransform;
        [SerializeField] public Transform turretTransform1;
        [SerializeField] public Transform turretTransform2;

        private PlayerController playerController;

        public void SetController(PlayerController playerController) => this.playerController = playerController;

        public void TakeBulletDamage(int damageToTake) => playerController.TakeDamage(damageToTake);

        private void Update() => playerController.HandlePlayerInput();
    } 
}