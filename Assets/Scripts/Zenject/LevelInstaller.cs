using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private GameObject _playerHealth;

    [SerializeField] private GameObject _bulletsPool;
    [SerializeField] private GameObject _enemyesPool;
    //[SerializeField] private GameObject enemyBulletsPool;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _playerTypeSwitch;

    //[SerializeField] private GameObject bonusSpawner;
    //[SerializeField] private GameObject uiExtraLife;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().FromComponentOn(_playerHealth).AsSingle();
        Container.Bind<PlayerTypeSwitch>().FromComponentOn(_playerTypeSwitch).AsSingle();

        Container.Bind<BulletsPool>().FromComponentOn(_bulletsPool).AsSingle();
        //Container.Bind<EnemyBulletsPool>().FromComponentOn(enemyBulletsPool).AsSingle();

        Container.Bind<EnemyesPool>().FromComponentOn(_enemyesPool).AsSingle();

        Container.Bind<LosePanel>().FromComponentOn(_losePanel).AsSingle();

        //Container.Bind<BonusSpawner>().FromComponentOn(bonusSpawner).AsSingle();

        //Container.Bind<UIExtraLife>().FromComponentOn(uiExtraLife).AsSingle();
    }
}