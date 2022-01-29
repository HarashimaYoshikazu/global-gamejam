﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class TileControllerBase : MonoBehaviour, IPointerDownHandler
{
    private const float PlayerDistance = 274 * 1.8f;

    [SerializeField] private Image _CoveredImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }

        var diff = transform.position.x - player.transform.position.x;
        if (diff > 0 && diff < PlayerDistance)
        {
            player.transform.parent = transform;
            player.transform.position = transform.position;
            TileEffect();
        }
    }

    protected abstract void TileEffect();

    public void SetVisibleCoverdImage(bool isVisible)
    {
        _CoveredImage.gameObject.SetActive(isVisible);
    }
}
