using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class selectpanel : MonoBehaviour, IPointerClickHandler
{
    public PanelManager panelManager;
    public Image background;

    private void Start()
    {
        panelManager.panelButtons.Add(this);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        panelManager.OnTabSelected(background,this);
    }

}
