using System.Linq;
using Xunit;

namespace Nancy.ViewEngines.Razor.Html.Tests
{
    public class SelectListItemExtensionsFixture
    {
        private TestEnum _field;

        [Fact]
        public void Should_create_list_items_from_enum()
        {
            var items = _field.ToSelectListItems().ToList();
            
            Assert.Equal(items[0].Text, "One");
            Assert.Equal(items[1].Text, "Two");
            Assert.Equal(items[2].Text, "Three");
        }

        [Fact]
        public void Selected_item_should_have_attribute_set()
        {
            var items = _field.ToSelectListItems(TestEnum.Three).ToList();
            
            Assert.Equal(items[2].Text, "Three");
            Assert.Equal(items[2].Selected, true);
        }

        public enum TestEnum
        {
            One, Two, Three
        }
    }
}
