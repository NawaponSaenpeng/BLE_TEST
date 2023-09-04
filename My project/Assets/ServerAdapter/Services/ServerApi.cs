using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class ServerApi 
{
    //private static GameServersAPI gameServersAPI;
    private static MockUPGameServerAPI gameServersAPI;
    private const byte autoRetry = 3;


    private static Dictionary<string, byte> countError = new Dictionary<string, byte>();

    public static void InitAquaristaAPI()
    {
        InternalAdapter internalAdapter = new InternalAdapter();
        //gameServersAPI = new GameServersAPI(internalAdapter);
        gameServersAPI = new MockUPGameServerAPI(internalAdapter);
    }

    public static async UniTask GetRewards(UnityAction<RewardsData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetRewards";

        await gameServersAPI.GetRewards((result) =>
        {
            ClearCountAutoRetry(code);
            onComplete?.Invoke(result);

        }, async (error) =>
        {
            await ErrorRequestCall(code, async () => { await GetRewards(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        });
    }

   

    public static async UniTask UnlockReward(UnlockRewardBody request, UnityAction<UnlockReward> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"UnlockFeeder";

        await gameServersAPI.UnlockReward(request, (result) =>
        {
            ClearCountAutoRetry(code);
            onComplete?.Invoke(result);

        }, async (error) =>
        {
            await ErrorRequestCall(code, async () => { await UnlockReward(request, onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        });
    }

    private static async UniTask ErrorRequestCall(string method, UnityAction onComplete, UnityAction onFailed)
    {
        //Auto Retry
        if (countError.ContainsKey(method))
        {
            byte counter = countError[method];
            counter++;
            countError[method] = counter;

            if (counter <= autoRetry)
            {
                await UniTask.Delay(3000);
                onComplete?.Invoke();

                return;
            }
        }
        else
        {
            countError.Add(method, 0);

            await UniTask.Delay(3000);
            onComplete?.Invoke();

            return;
        }

        //Reset auto retry.
        countError[method] = 0;

        onFailed?.Invoke();
    }

    public static async UniTask GetCoinData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetCoinData";
        gameServersAPI.GetCoinData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetCoinData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetDiamondData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetDiamondData";
        gameServersAPI.GetDiamondData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetDiamondData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetEnergyData(UnityAction<CurrencyItemData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetEnergyData";
        gameServersAPI.GetEnergyData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetEnergyData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetPlayerData(UnityAction<CurrencyData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetPlayerData";
        gameServersAPI.GetPlayerData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetPlayerData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }

    public static async UniTask GetStorageButtonSkinData(UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"GetStorageButtonSkinData";
        gameServersAPI.GetStorageButtonSkinData((data) =>
        {
            ClearCountAutoRetry(code);

            onComplete?.Invoke(data);
        }, async (error) =>
        {
            Debug.Log("error");
            await ErrorRequestCall(code, async () => { await GetStorageButtonSkinData(onComplete, onFailed); }, () =>
            {
                onFailed?.Invoke(error);

                Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                return;
            });
        }
        );
    }
    public static async UniTask Test(IDObject idObject, UnityAction<ThemeData> onComplete, UnityAction<ErrorRequest> onFailed)
    {
        string code = $"Test";
         gameServersAPI.Test(idObject, (data) =>
          {
              ClearCountAutoRetry(code);

              onComplete?.Invoke(data);
          }, async (error) =>
          {
              Debug.Log("error");
              await ErrorRequestCall(code, async () => { await Test(idObject, onComplete, onFailed); }, () =>
              {
                  onFailed?.Invoke(error);

                  Debug.LogWarning($"Failed to get data from server. \n{error.messege}");

                  return;
              });
          });

    }

    //When API callback successed it will remove counter autoretry.
    private static void ClearCountAutoRetry(string code)
    {
        if (countError.ContainsKey(code))
        {
            countError.Remove(code);
        }
    }
}
