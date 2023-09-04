using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;

public class MockUPGameServerAPI : IGameServersAdapter
{
    private IInternalAdapter internalAdapter;

    public MockUPGameServerAPI(IInternalAdapter internalAdapter)
    {
        this.internalAdapter = internalAdapter;
    }

    public async UniTask GetCoinData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyItemData coins = Resources.Load<CurrencyItemData>("Shop/Coin/CoinData");
        
        onComplete?.Invoke(coins);
    }

    public async UniTask GetDiamondData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyItemData diamonds = Resources.Load<CurrencyItemData>("Shop/Diamond/DiamondData");

        onComplete?.Invoke(diamonds);
    }

    public async UniTask GetEnergyData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyItemData energys = Resources.Load<CurrencyItemData>("Shop/Energy/EnergyData");

        onComplete?.Invoke(energys);
    }

    public async UniTask GetPlayerData(UnityAction<CurrencyData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        CurrencyData data = Resources.Load<CurrencyData>("Currency/CurrencyData");

        onComplete?.Invoke(data);
    }

    public async UniTask GetRewards(UnityAction<RewardsData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        RewardsData rewardsData = new RewardsData();
        rewardsData.rewards = "mock up GetRewards";

        onComplete?.Invoke(rewardsData);
    }

    public async UniTask GetStorageButtonSkinData(UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        ThemeData data = Resources.Load<ThemeData>("Storage/Button/ThemeData");

        onComplete?.Invoke(data);
    }

    public async UniTask Test(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        Debug.Log(idObject.idItem);
        int currencyDimonds = DataCurrency.instance.getData.diamonds;
        ThemeData themeShop = Resources.Load<ThemeData>("Shop/Theme/ButtonSkinData");
        ThemeData storageButtonSkinData = Resources.Load<ThemeData>("Storage/Button/ThemeData");
        foreach (ThemeButtonSkinInfo buttonSkin in themeShop.skinData)
        {
            if (buttonSkin.ID == idObject.idItem)
            {
                currencyDimonds -= buttonSkin.price;
                themeShop.Remove(buttonSkin);
                buttonSkin.alreadyBuy = true;
                themeShop.Add(buttonSkin);
                themeShop.Save(themeShop);
                DataCurrency.instance.getData.SaveDiamonds(currencyDimonds);

                storageButtonSkinData.Add(buttonSkin);
                storageButtonSkinData.Save(storageButtonSkinData);
                ThemeShow.instance.CheckSkin();
              
            }

        }
        onComplete?.Invoke(storageButtonSkinData);

    }

    public async UniTask UnlockReward(UnlockRewardBody unlockRewardBody, UnityAction<UnlockReward> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        UnlockReward rewardsData = new UnlockReward();
        rewardsData.unlockReward = "mock up UnlockReward";

        onComplete?.Invoke(rewardsData);
    }
}
