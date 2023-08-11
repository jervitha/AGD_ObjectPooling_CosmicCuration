using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerView : MonoBehaviour, IDamageable
    {
        [SerializeField] public Transform canonTransform;
        [SerializeField] public Transform turretTransform1;
        [SerializeField] public Transform turretTransform2;
        [SerializeField] public GameObject shield;

        private PlayerController playerController;

        public void SetController(PlayerController playerController) => this.playerController = playerController;

        private void Update() => playerController.HandlePlayerInput();

        public void TakeDamage(int damageToTake) => playerController.TakeDamage(damageToTake);

        public void EnableShieldUi()
        {
            shield.SetActive(true);
        }

        public void DisableShieldUi()
        {
            shield.SetActive(false);
        }
    } 
}