using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace NerdStore.WebApp.MVC.Controllers.Base
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notification;
        private readonly IMediatorHandler _mediatorHandler;
        protected Guid ClientId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected ControllerBase(INotificationHandler<DomainNotification> notification, IMediatorHandler mediatorHandler)
        {
            _notification = (DomainNotificationHandler)notification;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida() => !_notification.TemNotificacao();
        
        protected IEnumerable<string> ObterMensagemErro()
        {
            return _notification.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        protected void NotificarError(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }
}