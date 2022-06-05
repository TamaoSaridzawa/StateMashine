using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _player.Dying += OnDying;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDying;
    }

    public void OnDying()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }
}
