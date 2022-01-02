using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthIconPrefab;
    private List<GameObject> _healthIcons = new List<GameObject>();

    public void SetUp(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(_healthIconPrefab, transform);
            _healthIcons.Add(newIcon);
        }
    }

    public void DysplayHealth(int currentHeathValue)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            if (i < currentHeathValue)
            {
                _healthIcons[i].SetActive(true);
            }
            else
            {
                _healthIcons[i].SetActive(false);
            }
        }
    }
}