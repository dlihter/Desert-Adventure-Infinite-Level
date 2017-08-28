using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject CurrentWeapon;
    public List<GameObject> Weapons= new List<GameObject>();
    public int _currentWeaponIndex = 0;

    private void Start()
    {
        CurrentWeapon = Weapons[_currentWeaponIndex];
    }
    private void Update()
    {
        WeaponSwitch();
    }

    private void WeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _currentWeaponIndex++;

            if (_currentWeaponIndex > Weapons.Count - 1)
                _currentWeaponIndex = 0;
            if (_currentWeaponIndex < Weapons.Count)
            {
                CurrentWeapon = Weapons[_currentWeaponIndex];
            }
        }
    }

}
