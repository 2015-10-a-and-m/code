using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using code.features.catalog_browsing;
using code.test_utilities;
using developwithpassion.specification.adapters.rhino_mocks;
using Machine.Specifications;

namespace code.spikes
{
  public class ExpressionsSpike
  {
    public abstract class concern : spec
    {
    }

    public class when_messing_around_with_expression : concern
    {
      It can_create_an_expression_tree_on_the_fly = () =>
      {
        Func<int, bool> even_number = x => x % 2 == 0;

        even_number(2).ShouldBeTrue();

        var param = Expression.Parameter(typeof(int), "x");
        var number_2 = Expression.Constant(2);
        var number_0 = Expression.Constant(0);

        var mod_2 = Expression.Modulo(param, number_2);
        var equal_0 = Expression.Equal(mod_2, number_0);

        var complete = Expression.Lambda<Func<int, bool>>(equal_0,
          param);

        var generated = complete.Compile();

        generated(2).ShouldBeTrue();
      };

      class Person
      {
        public string names { get; set; }
      }

      public class Token<Value>
      {
        string key;

        public Token(string key)
        {
          this.key = key;
        }

        public Value map_from(IDictionary<string, string> data)
        {
          return default(Value);
        } 
      }

      public interface IProvideApiBehaviour
      {
        IEnumerable<Department> get_departments();
      }

      public class ReportColumns
      {
        public static Token<string> name  = new Token<string>("name");
        public static Token<DateTime> date  = new Token<DateTime>("date");
      }

      It get_the_name_of_an_attribute = () =>
      {
        var builder = Objects.expressions.to_target<Person>();
        var raw_record = new Dictionary<string, string>();

        var mapped_value = ReportColumns.name.map_from(raw_record);

        var attribute_name = builder.attribute_name(x => x.names);
        
      };
        
    }
  }
}