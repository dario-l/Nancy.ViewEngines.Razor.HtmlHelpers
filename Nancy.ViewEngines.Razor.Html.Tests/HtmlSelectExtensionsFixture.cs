using Xunit;

namespace Nancy.ViewEngines.Razor.Html.Tests
{
    public class HtmlSelectExtensionsFixture
    {
        private readonly TestModel _model;
        private readonly HtmlHelpers<TestModel> _helpers;
        private readonly string _defaultOption;

        public HtmlSelectExtensionsFixture()
        {
            _model = new TestModel { TestEnum = SelectListItemExtensionsFixture.TestEnum.Two };
            _helpers = new HtmlHelpers<TestModel>(null, null, _model);
            _defaultOption = SelectListItemExtensionsFixture.TestEnum.Three.ToString();
        }

        [Fact]
        public void When_enum_provided_with_selected_value_value_is_selected_in_markup()
        {
            var items = _model.TestEnum.ToSelectListItems(_model.TestEnum);

            var output = _helpers.DropDownListFor(x => x.TestEnum, _defaultOption, items);

            Assert.Contains("<option selected=\"selected\" value=\"Two\">Two</option>", output.ToHtmlString());
        }

        [Fact]
        public void When_enum_provided_items_generated_from_enum()
        {
            var output = _helpers.DropDownListFor(x => x.TestEnum, new {  });

            Assert.Contains("<select id=\"TestEnum\" name=\"TestEnum\">", output.ToHtmlString());
            Assert.Contains("<option selected=\"selected\" value=\"Two\">Two</option>", output.ToHtmlString());
        }

        public class TestModel
        {
            public SelectListItemExtensionsFixture.TestEnum TestEnum { get; set; }
        }
    }
}
