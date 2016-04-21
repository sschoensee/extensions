﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Signum.Engine.Authorization;
using Signum.Entities;
using Signum.Entities.Authorization;
using Signum.Services;
using Signum.Utilities;
using Signum.React.Facades;
using Signum.React.Authorization;
using Signum.Engine.Cache;
using Signum.Engine;
using Signum.Entities.Cache;
using Signum.Utilities.ExpressionTrees;
using Signum.Entities.Processes;
using Signum.Engine.Processes;
using System.Threading;
using Signum.React.ApiControllers;
using Signum.Engine.Basics;
using Signum.Entities.Mailing;
using Signum.Engine.Mailing;

namespace Signum.React.Mailing
{
    public class MailingController : ApiController
    {
        [Route("api/asyncEmailSender/view"), HttpGet]
        public AsyncEmailSenderState View()
        {
            AsyncEmailSenderPermission.ViewAsyncEmailSenderPanel.AssertAuthorized();

            AsyncEmailSenderState state = AsyncEmailSenderLogic.ExecutionState();

            return state;
        }

        [Route("api/asyncEmailSender/start"), HttpPost]
        public void Start()
        {
            AsyncEmailSenderPermission.ViewAsyncEmailSenderPanel.AssertAuthorized();

            AsyncEmailSenderLogic.StartRunningEmailSenderAsync(0);

            Thread.Sleep(1000);
        }

        [Route("api/asyncEmailSender/stop"), HttpPost]
        public void Stop()
        {
            AsyncEmailSenderPermission.ViewAsyncEmailSenderPanel.AssertAuthorized();

            AsyncEmailSenderLogic.Stop();

            Thread.Sleep(1000);
        }
    }
}