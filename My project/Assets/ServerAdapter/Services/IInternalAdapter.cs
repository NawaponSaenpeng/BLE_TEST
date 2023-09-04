using Cysharp.Threading.Tasks;

public interface IInternalAdapter 
{
    UniTask<TOut> Get<TOut>(string requestPath);
    UniTask<TOut> Get<TOut, TInput>(string requestPath, TInput body);
    UniTask<TOut> Post<TOut>(string requestPath);
    UniTask<TOut> Post<TOut, TInput>(string requestPath, TInput body);
    UniTask<TOut> Put<TOut, TInput>(string requestPath, TInput body);
    UniTask<TOut> Put<TOut>(string requestPath);
    UniTask<TOut> Delete<TOut>(string requestPath);
    UniTask<TOut> Delete<TOut, TInput>(string requestPath, TInput body);
}
