using Microsoft.AspNetCore.Mvc;
using SharedKernal.Common;
using SharedKernal.Middlewares.Basees;

namespace DoctorAppointment.Presentation.API.Controllers
{

    [ApiController]
    [Route(APIRoute.VersioningTemplate)]
    public abstract class BaseController : ControllerBase
    {
        #region Properties
        public Presenter Presenter { get; set; }
        //protected ITokenHandler TokenHandler { get; }
        #endregion

        #region Constructor
        public BaseController()
        {
            //this.Presenter = Engine.Container.GetRequiredService<Presenter>();
            //this.TokenHandler = Engine.Container.GetRequiredService<ITokenHandler>();
        }
        #endregion

        #region Methods
        //[NonAction]
        //public int GetCurrentUserId()
        //{
        //    List<Claim> result = TokenHandler.GetTokenData(Request);
        //    return int.TryParse(result.FirstOrDefault(item => item.Type.Equals("sub", System.StringComparison.Ordinal)).Value, out int userId) ? userId : default;
        //}
        #endregion
    }
}
