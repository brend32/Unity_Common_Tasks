using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SOLID
{
    public class PistolWeapon : MonoBehaviour
    {
        public float ReloadCooldown = 3;
        public int MagazineSize = 8;
        public int BulletsInInventory = 32;
        public int Bullets = 8;
        
        public Image CooldownDisplay;
        public TextMeshProUGUI BulletsText;

        private Coroutine _reloadCoroutine;
        
        public void Equip()
        {
            gameObject.SetActive(true);
            _reloadCoroutine = null;
            UpdateText();
        }

        public void Reload()
        {
            if (_reloadCoroutine != null)
                return;
            
            if (BulletsInInventory <= 0)
            {
                Debug.Log("Reload failed; No bullets in inventory");
                return;
            }

            if (Bullets >= MagazineSize)
            {
                Debug.Log("Reload failed; Has enough bullets");
                return;
            }
            
            Debug.Log("Reloading...");
            _reloadCoroutine = StartCoroutine(ReloadCoroutine());
        }

        public void Fire()
        {
            if (_reloadCoroutine != null)
            {
                Debug.Log("Attack failed due to reload");
                return;
            }

            if (Bullets <= 0)
            {
                Debug.Log("Attack failed; No bullets in magazine");
                return;
            }
            
            Debug.Log("Pistol attack");
            Bullets--;
            UpdateText();

            if (Bullets <= 0)
            {
                transform.parent.GetComponent<Player>().FireButton.interactable = false;
            }
        }

        private void OnDisable()
        {
            _reloadCoroutine = null;
        }

        private IEnumerator ReloadCoroutine()
        {
            CooldownDisplay.enabled = true;
            var time = ReloadCooldown;

            while (time > 0)
            {
                time -= Time.deltaTime;
                CooldownDisplay.fillAmount = time / ReloadCooldown;
                yield return null;
            }

            var reloadAmount = Mathf.Min(MagazineSize, BulletsInInventory, MagazineSize - Bullets);
            BulletsInInventory -= reloadAmount;
            Bullets += reloadAmount;
            UpdateText();
            CooldownDisplay.enabled = false;
            transform.parent.GetComponent<Player>().FireButton.interactable = true;
            Debug.Log("Reloaded");
            _reloadCoroutine = null;
        }

        private void UpdateText()
        {
            BulletsText.text = $"{Bullets}/{BulletsInInventory}";
        }
    }
}