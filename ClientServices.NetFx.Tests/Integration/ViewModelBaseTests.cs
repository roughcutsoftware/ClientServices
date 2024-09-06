using System.Collections.Generic;
using System.Threading.Tasks;
using ClientServices.Base;
using ClientServices.Dtos;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ClientServices.NetFx.Tests.Integration
{
    public class ViewModelBaseTests
    {

        private string baseUrl = "https://jsonplaceholder.typicode.com";
        ViewModelBase<TodoItemDto> _viewModel;

        [SetUp]
        public void Setup()
        {
            _viewModel = new ViewModelBase<TodoItemDto>(baseUrl);
        }

        [TestCase]
        public async Task Should_GetTodosListFrom_RestClient()
        {
            // arrange
            // initialize the HttpClient
            _viewModel.RestClient.BaseAddress = new System.Uri(baseUrl);

            // act - get the todos list
            var response = await _viewModel.RestClient.GetAsync(TodoAction.GetTodos);

            // assert - check if the response is successful
            response.IsSuccessStatusCode.Should().Be(true);

            // assert - check if the response content is not null
            var content = await response.Content.ReadAsStringAsync();
            content.Should().NotBeNullOrEmpty();

            // assert - check if the response content is a valid json
            content.Should().Contain("userId");

            // assert - check if the response content is a valid json
            content.Should().Contain("id");

            // assert - check if the response content size is greater than 100
            content.Length.Should().BeGreaterThan(100);

            // cast items into a list of TodoItemDto
            var items = JsonConvert.DeserializeObject<List<TodoItemDto>>(content);

            // assert - check if the items is not null
            items.Should().NotBeNull();
            items.Count.Should().BeGreaterOrEqualTo(10);

        }

        [TestCase]
        public async Task Should_GetTodosListFrom_ViewModel()
        {
            // arrange / act - get the todos list
            List<TodoItemDto> todosList = await _viewModel.GetListAsync(TodoAction.GetTodos);

            // assert - check if the items is not null
            todosList.Should().NotBeNull();

            // assert - check if the items count is greater than 10
            todosList.Count.Should().BeGreaterOrEqualTo(10);

        }
    }
}