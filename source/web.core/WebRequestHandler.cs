﻿namespace code.web.core
{
  public class WebRequestHandler : IHandleAllTheWebRequests
  {
    IGetWebRequestHandlers handlers;

    public WebRequestHandler(IGetWebRequestHandlers handlers)
    {
      this.handlers = handlers;
    }

    public void process(IProvideDetailsToHandlers web_request)
    {
      var handler = handlers.get_handler_for_request(web_request);
      handler.process(web_request);
    }
  }
}