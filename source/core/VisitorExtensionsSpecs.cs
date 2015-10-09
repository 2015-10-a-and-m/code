﻿using System.Linq;
using developwithpassion.specification.adapters.rhino_mocks;
using Machine.Specifications;

namespace code.core
{
  public class VisitorExtensionSpecs
  {
    public abstract class concern : spec
    {
    }

    public class when_visiting_items_in_an_iterator : concern
    {
      Because b = () =>
        Enumerable.Range(1, 10).each(x => items_visited++);

      It processes_each_item_in_the_iterator_using_the_visitor = () =>
        items_visited.ShouldEqual(10);

      static int items_visited;
    }
  }
}