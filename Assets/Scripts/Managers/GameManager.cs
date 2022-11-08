using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform _containerUI;

    [SerializeField]
    private PoolInfo _poolStruct;

    private StateMachine<IStateUI> stateMachineUI;
    private ResourceLoaderService resourceLoaderService;
    private GameState gameState;
    private MenuState menuState;

    private EventManager eventManager;
    private SpawnManager spawnManager;
    private PoolManager<Cube> poolManager;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        resourceLoaderService = new ResourceLoaderService();
        eventManager = new EventManager();
        poolManager = new PoolManager<Cube>(_poolStruct.Cube, _poolStruct.PoolCount, _poolStruct.PoolContainer);
        poolManager.AutoExpand = _poolStruct.AutoExpand;
        spawnManager = new SpawnManager(poolManager, resourceLoaderService); 

        menuState = new MenuState(resourceLoaderService, _containerUI);
        gameState = new GameState(resourceLoaderService, _containerUI);


        stateMachineUI = new StateMachine<IStateUI>();
        stateMachineUI.Init(menuState);

        InitAction();
    }

    private void InitAction()
    {
        eventManager.OnGameStateEvent.AddListener(() => stateMachineUI.ChangeState(gameState));
        eventManager.OnMenuStateEvent.AddListener(() => stateMachineUI.ChangeState(menuState));
    }
}


