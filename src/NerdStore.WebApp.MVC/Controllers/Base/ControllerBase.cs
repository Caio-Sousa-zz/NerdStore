using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers.Base
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notification;
        private readonly IMediatorHandler _mediatorHandler;
        protected Guid ClientId = Guid.Parse("9AABCCBB-46A7-43E8-BEC3-D316FFCB34D6");

        protected ControllerBase(INotificationHandler<DomainNotification> notification, IMediatorHandler mediatorHandler)
        {
            _notification = (DomainNotificationHandler)notification;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida() => !_notification.TemNotificacao();

        protected void NotificarError(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }
}