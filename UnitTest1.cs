using System.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal;
using RestSharp;

namespace challange2;

[TestFixture]
public class Tests
{
private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://jsonplaceholder.typicode.com");
        }

        // Test for GET Request
        [Test]
        public void Test_GetPostById()
        {
            var request = new RestRequest("/posts/1", Method.Get);
            var response = _client.Execute(request);

            // Log the request and response
            TestContext.WriteLine("GET Request: " + request.Resource);
            TestContext.WriteLine("Response: " + response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var jsonResponse = JObject.Parse(response.Content);

            Assert.That(jsonResponse["userId"].ToString(), Is.EqualTo("1"));
            Assert.That(jsonResponse["id"].ToString(), Is.EqualTo("1"));
            Assert.That(jsonResponse["title"].ToString(), Is.EqualTo("sunt aut facere repellat provident occaecati excepturi optio reprehenderit"));
            Assert.That(jsonResponse["body"].ToString(), Is.EqualTo("quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"));
        }

        // Test for POST Request
        [Test]
        public void Test_CreatePost()
        {
            var request = new RestRequest("/posts", Method.Post);
            request.AddJsonBody(new
            {
                userId = 1,
                title = "Post#1",
                body = "Post for challenge #2"
            });

            var response = _client.Execute(request);

            // Log the request and response
            TestContext.WriteLine("POST Request: " + request.Resource);
            TestContext.WriteLine("Response: " + response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            var jsonResponse = JObject.Parse(response.Content);

            Assert.That(jsonResponse["userId"].ToString(), Is.EqualTo("1"));
            Assert.That(jsonResponse["title"].ToString(), Is.EqualTo("Post#1"));
            Assert.That(jsonResponse["body"].ToString(), Is.EqualTo("Post for challenge #2"));
        }

        // Test for PUT Request
        [Test]
        public void Test_UpdatePost()
        {
            var request = new RestRequest("/posts/1", Method.Put);
            request.AddJsonBody(new
            {
                userId = 1,
                title = "Updated Post",
                body = "updated post"
            });

            var response = _client.Execute(request);

            // Log the request and response
            TestContext.WriteLine("PUT Request: " + request.Resource);
            TestContext.WriteLine("Response: " + response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var jsonResponse = JObject.Parse(response.Content);
            Assert.That(jsonResponse["userId"].ToString(), Is.EqualTo("1"));
            Assert.That(jsonResponse["title"].ToString(), Is.EqualTo("Updated Post"));
            Assert.That(jsonResponse["body"].ToString(), Is.EqualTo("updated post"));
        }

        // Test for DELETE Request
        [Test]
        public void Test_DeletePost()
        {
            var request = new RestRequest("/posts/1", Method.Delete);
            var response = _client.Execute(request);

            // Log the request and response
            TestContext.WriteLine("DELETE Request: " + request.Resource);
            TestContext.WriteLine("Response: " + response.Content);

            Assert.That(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent, Is.True);
        }


        // TearDown to dispose the client and log test results
        [TearDown]
        public void TearDown()
        {
            _client.Dispose(); // Dispose of the RestClient
            TestContext.WriteLine($"Test completed at: {DateTime.Now}");
        }
}