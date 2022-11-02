using Microsoft.AspNetCore.Mvc;
using Core.Framework;
using AutoMapper;

namespace Origin.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly log4net.ILog _log;
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapp)
        {
            _mapper = mapp;
            _log = log4net.LogManager.GetLogger(this.ToString());
        }

        protected GenericResult HandleException(Exception ex, bool warn = false)
        {
            string message = ExceptionHelper.GetMessage(ex);
            if (warn)
                _log.Warn(message);
            else
                _log.Error(message);
            return new GenericResult(message, true);
        }

        protected void _LogDebug(string message, object? entity = null)
        {
            if (entity is null)
                _log.Debug(message);
            else
                _log.Debug(string.Concat(message, " - ", Core.Externals.JsonConvert.Serialize(entity)));
        }

        protected void _LogInfo(string message, object? entity = null)
        {
            if (entity is null)
                _log.Info(message);
            else
                _log.Info(string.Concat(message, " - ", Core.Externals.JsonConvert.Serialize(entity)));
        }

        protected void _LogError(string message, object? entity = null)
        {
            if (entity is null)
                _log.Error(message);
            else
                _log.Error(string.Concat(message, " - ", Core.Externals.JsonConvert.Serialize(entity)));
        }
        protected void _LogWarn(string message, object? entity = null)
        {
            if (entity is null)
                _log.Warn(message);
            else
                _log.Warn(string.Concat(message, " - ", Core.Externals.JsonConvert.Serialize(entity)));
        }

    }
}