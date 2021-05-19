using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public selectpanel active;
    public List<selectpanel> panelButtons;
    public List<GameObject> Panel;

    public void OnTabSelected(Image button,selectpanel selectpanel)
    {
        active = selectpanel;
        ResetTabs();
        button.gameObject.SetActive(false);
        int index = button.transform.GetSiblingIndex() / 2;
        for (int i = 0; i < Panel.Count; i++)
        {
            if (i == index)
            {
                Panel[i].SetActive(true);
            }
            else
            {
                Panel[i].SetActive(false);
            }
        }
    }
    public void ResetTabs()
    {
        foreach (selectpanel button in panelButtons)
        {
            if (active != null && button == active)
            {
                continue;
            }
            button.gameObject.SetActive(true);
        }
    }

}
