using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DjPageFlash
{
    public abstract class BasePageFlash : IHttpModule
    {
        #region IHttpModule 成员

        public virtual void Dispose()
        {
        }

        public virtual void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            //context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            OnBeginRequest(app);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            OnEndRequest(app);
        }

        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            OnBeginRequest(app);
        }

        #endregion

        protected abstract void OnBeginRequest(HttpApplication app);

        protected abstract void OnEndRequest(HttpApplication app);
    }
}
