using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public Sprite tabIdle;
    public Sprite tabHoverd;
    public Sprite tabActive;
    public TabButton selecteTab;
    public List<TabButton> tabButtons;
    public List<GameObject> Panel;

    public void AddButtunToTab(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }
    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selecteTab == null || button != selecteTab)
        {
            button.background.sprite = tabHoverd;
        }
    }
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }
    public void OnTabSelected(TabButton button)
    {
        selecteTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
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
        foreach (TabButton button in tabButtons)
        {
            if (selecteTab != null && button == selecteTab)
            {
                continue;
            }
            button.background.sprite = tabIdle;
        }
    }
}
