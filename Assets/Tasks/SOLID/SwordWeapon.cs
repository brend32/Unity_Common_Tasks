using System;
using UnityEngine;
using UnityEngine.UI;

namespace SOLID
{
    public class SwordWeapon : MonoBehaviour
    {
        public float Cooldown = 3;
        public float EquipCooldown = 1;
        public Image CooldownDisplay;

        private float _cooldownTime;
        private float _cooldownDuration;
        
        public void Equip()
        {
            gameObject.SetActive(true);
            _cooldownTime = EquipCooldown;
            _cooldownDuration = EquipCooldown;
        }

        public void Attack()
        {
            if (_cooldownTime > 0)
            {
                Debug.Log("Attack failed due to cooldown");
                return;
            }
            
            Debug.Log("Sword attack");
            _cooldownTime = Cooldown;
            _cooldownDuration = Cooldown;
        }

        public void Update()
        {
            if (_cooldownTime > 0)
            {
                _cooldownTime -= Time.deltaTime;
                CooldownDisplay.fillAmount = _cooldownTime / _cooldownDuration;
                CooldownDisplay.enabled = true;
            }
            else
            {
                CooldownDisplay.enabled = false;
            }
        }
    }
}