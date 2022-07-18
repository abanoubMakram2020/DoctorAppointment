using AutoMapper;
using Microsoft.AspNetCore.Http;
using SharedKernal.DataRepositories;
using SharedKernal.Middlewares.Handler;
using SharedKernal.Middlewares.JWTSettings;
using SharedKernal.Middlewares.MemoryCache;
using SharedKernal.Middlewares.ResourcesReader.Message;

namespace SharedKernal.Middlewares.Basees
{
    public class BaseUseCase
    {
        public IMessageResourceReader MessageResource { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public IMapper Mapper { get; set; }
        public IMemoryCacheService MemoryCacheService { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public ITokenHandler TokenHandler { get; set; }
        public ICommonHandle CommonHandle { get; set; }

        protected const int SERVICE_ID = 52;
        protected const int REQUEST_TYPE_ID = 94;
        protected readonly string CURRENT_CULTURE = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();
    }

}
