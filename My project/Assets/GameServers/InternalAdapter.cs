using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class InternalAdapter : IInternalAdapter
{
    private const string REQUEST_ERROR_PATH = "apiCheckRequest";
    private string baseUrl = $"api path";

    #region RequestGET

    public async UniTask<TOut> Get<TOut, TInput>(string requestPath, TInput body)
    {
        var bodyRaw = JsonConvert.SerializeObject(body);

        string url = $"{baseUrl}{requestPath}";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyRaw));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {
            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;

            return JsonConvert.DeserializeObject<TOut>(text);

        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e}");
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }

    public async UniTask<TOut> Get<TOut>(string requestPath)
    {
        string url = $"{baseUrl}{requestPath}";

        UnityWebRequest request = UnityWebRequest.Get(url);

        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {
            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;

            return JsonConvert.DeserializeObject<TOut>(text);

        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e}");
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }

    #endregion


    #region RequestPOST
    public async UniTask<TOut> Post<TOut, TInput>(string requestPath, TInput body)
    {
        var bodyRaw = JsonConvert.SerializeObject(body);

        string url = $"{baseUrl}{requestPath}";

        UnityWebRequest request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyRaw));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {
            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;

            return JsonConvert.DeserializeObject<TOut>(text);

        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e.Message}");
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }

    public async UniTask<TOut> Post<TOut>(string requestPath)
    {
        string url = $"{baseUrl}{requestPath}";

        UnityWebRequest request = UnityWebRequest.Post(url, string.Empty);

        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {

            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;

            return JsonConvert.DeserializeObject<TOut>(text);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e}");
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }
    #endregion

    #region RequestPut
    public async UniTask<TOut> Put<TOut, TInput>(string requestPath, TInput body)
    {
        var bodyRaw = JsonConvert.SerializeObject(body);

        string url = $"{baseUrl}{requestPath}";

        UnityWebRequest request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPUT);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyRaw));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {
            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;

            return JsonConvert.DeserializeObject<TOut>(text);

        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e}");
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }

    public async UniTask<TOut> Put<TOut>(string requestPath)
    {
        string url = $"{baseUrl}{requestPath}";

        UnityWebRequest request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPUT);

        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {
            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;

            return JsonConvert.DeserializeObject<TOut>(text);
        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e}");
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }
    #endregion

    #region RequestDELETE

    public async UniTask<TOut> Delete<TOut, TInput>(string requestPath, TInput body)
    {
        var bodyRaw = JsonConvert.SerializeObject(body);

        string url = $"{baseUrl}{requestPath}";

        UnityWebRequest request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbDELETE);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyRaw));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {
            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;
            return JsonConvert.DeserializeObject<TOut>(text);

        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e}");
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }

    public async UniTask<TOut> Delete<TOut>(string requestPath)
    {
        string url = $"{baseUrl}{requestPath}";
        Debug.Log(url);
        UnityWebRequest request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbDELETE);

        request.SetRequestHeader("authorization", "Bearer " + "");
        request.SetRequestHeader("Content-Type", "application/json");

        try
        {

            await request.SendWebRequest();

            if (request.responseCode != 200) // responseCode 200 data extraction success
            {
                return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
            }

            string text = request.downloadHandler.text;

            return JsonConvert.DeserializeObject<TOut>(text);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return JsonConvert.DeserializeObject<TOut>(GetErrorRequest(request));
        }
    }


    #endregion

    private string GetErrorRequest(UnityWebRequest request)
    {
        var requestError = new Dictionary<string, ErrorRequest>();
        var response = JsonConvert.DeserializeObject<Dictionary<string, object>>(request.downloadHandler.text);

        ErrorRequest errorRequest = new ErrorRequest();
        errorRequest.responseCode = request.responseCode;
        errorRequest.isSucceed = false;
        errorRequest.responseAPICode = JsonConvert.DeserializeObject<int>(JsonConvert.SerializeObject(response["code"]));
        errorRequest.messege = JsonConvert.DeserializeObject<string>(JsonConvert.SerializeObject(response["message"]));

        requestError.Add(REQUEST_ERROR_PATH, errorRequest);

        var errorText = JsonConvert.SerializeObject(requestError);

        return errorText;
    }
}
