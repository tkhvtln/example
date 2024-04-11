using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SaveController _saveController;

    public override void InstallBindings()
    {
        Container.Bind<GameController>().FromInstance(_gameController).AsSingle().NonLazy();
        Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
        Container.Bind<SaveController>().FromInstance(_saveController).AsSingle().NonLazy();
    }
}