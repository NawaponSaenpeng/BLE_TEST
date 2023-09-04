using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IGameServersAdapter 
{
    UniTask GetRewards(UnityAction<RewardsData> onComplete, UnityAction<ErrorRequest> onFailed);
    UniTask Test(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed);
    UniTask GetStorageButtonSkinData(UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed);
    UniTask GetCoinData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed);
    UniTask GetDiamondData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed);
    UniTask GetEnergyData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed);
    UniTask GetPlayerData(UnityAction<CurrencyData> onComplete, UnityAction<ErrorRequest> onFailed);
    UniTask UnlockReward(UnlockRewardBody unlockRewardBody, UnityAction<UnlockReward> onComplete, UnityAction<ErrorRequest> onFailed);
}
