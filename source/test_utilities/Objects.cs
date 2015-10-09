using System;
using System.IO;
using System.Linq.Expressions;
using System.Web;
using developwithpassion.specifications.extensions;

namespace code.test_utilities
{
  public class Objects
  {
    public class expressions
    {
      public static ExpressionBuilder<Item> to_target<Item>()
      {
        return new ExpressionBuilder<Item>();
      }
    }
    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://blah/blah.aspx", String.Empty);
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }
    }  
  }

  public class ExpressionBuilder<Item>
  {
    public string attribute_name(Expression<Func<Item, object>> accessor)
    {
      return accessor.Body.downcast_to<MemberExpression>().Member.Name;
    }
  }
}