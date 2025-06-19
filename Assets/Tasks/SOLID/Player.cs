using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SOLID
{
    public class Player : MonoBehaviour
    {
        public List<WeaponType> SlotsMap;
        public HandWeapon Hand;
        public SwordWeapon Sword;
        public PistolWeapon Pistol;
        public int EquipedIndex;

        public Button ReloadButton;
        public Button FireButton;

        private void Start()
        {
            ReloadButton.onClick.AddListener(Reload);
            FireButton.onClick.AddListener(Attack);
            
            Equip(0);
        }

        public void Equip(int slotId)
        {
            EquipedIndex = slotId;
            
            Hand.gameObject.SetActive(false);
            Sword.gameObject.SetActive(false);
            Pistol.gameObject.SetActive(false);

            WeaponType weaponType = SlotsMap[EquipedIndex];
            switch (weaponType)
            {
                case WeaponType.Hand:
                    Hand.Equip();
                    ReloadButton.gameObject.SetActive(false);
                    break;
                
                case WeaponType.Sword:
                    Sword.Equip();
                    ReloadButton.gameObject.SetActive(false);
                    break;
                
                case WeaponType.Pistol:
                    Pistol.Equip();
                    ReloadButton.gameObject.SetActive(true);
                    break;
            }
        }

        public void Attack()
        {
            WeaponType weaponType = SlotsMap[EquipedIndex];
            switch (weaponType)
            {
                case WeaponType.Hand:
                    Hand.Hit();
                    break;
                
                case WeaponType.Sword:
                    Sword.Attack();
                    break;
                
                case WeaponType.Pistol:
                    Pistol.Fire();
                    break;
            } 
        }

        public void Reload()
        {
            WeaponType weaponType = SlotsMap[EquipedIndex];

            if (weaponType == WeaponType.Pistol)
            {
                Pistol.Reload();
            }
        }
    }
}
