

namespace SharedKernal.Middlewares.Basees
{
    public interface IBaseUseCase<TRequest, TResponse>

    {
        Task<ResponseResultDto<TResponse>> Handle(BaseRequestDto<TRequest> model);
    }

    public interface IBaseUseCase<TResponse>
    {
        Task<ResponseResultDto<TResponse>> Handle();
    }
}
