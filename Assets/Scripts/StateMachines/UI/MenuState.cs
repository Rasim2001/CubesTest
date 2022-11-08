using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IStateUI
{
    private MenuView menuView;

    public MenuState(ResourceLoaderService resourceLoaderService, Transform containerUI)
    {
        menuView = GameObject.Instantiate(resourceLoaderService.Prefabs.MENU_VIEW.GetComponent<MenuView>(), containerUI);
        menuView.Init();
    }

    public void Enter()
    {
        menuView.gameObject.SetActive(true);
        menuView.OnPlayButtonEvent += EventManager.Instance.SendGameStateEvent;
    }

    public void Exit()
    {
        menuView.gameObject.SetActive(false);
        menuView.OnPlayButtonEvent -= EventManager.Instance.SendGameStateEvent;
    }
}
