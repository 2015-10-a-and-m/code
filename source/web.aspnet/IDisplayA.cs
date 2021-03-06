﻿using System.Web;
using System.Web.UI;

namespace code.web.aspnet
{
  public interface IDisplayA<Report> : IHttpHandler
  {
    Report report { get; set; } 
  }

  public class DisplayA<Report> : Page, IDisplayA<Report>
  {
    public Report report { get; set; }
  }
}