using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest;
using Twilio.Rest.Api.V2010.Account;

namespace Twilio.Tests.Rest.Api.V2010.Account {

    [TestFixture]
    public class MessageTest : TwilioTest {
        [SetUp]
        public void SetUp() {
        }
    
        [Test]
        public void TestCreateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json");
            request.AddPostParam("To", Serialize(new Twilio.Types.PhoneNumber("+123456789")));
            request.AddPostParam("From", Serialize(new Twilio.Types.PhoneNumber("+987654321")));
            request.AddPostParam("Body", Serialize("body"));
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                MessageResource.Creator(new Twilio.Types.PhoneNumber("+123456789"), new Twilio.Types.PhoneNumber("+987654321"), "body", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestCreateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.Created,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Thu, 30 Jul 2015 20:12:31 +0000\",\"date_sent\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = MessageResource.Creator(new Twilio.Types.PhoneNumber("+123456789"), new Twilio.Types.PhoneNumber("+987654321"), "body", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Create(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestDeleteRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.DELETE,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                MessageResource.Deleter("MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestDeleteResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.NoContent,
                                                  "null"));
            
            MessageResource.Deleter("MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Delete(twilioRestClient);
        }
    
        [Test]
        public void TestFetchRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                MessageResource.Fetcher("MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestFetchResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Thu, 30 Jul 2015 20:12:31 +0000\",\"date_sent\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = MessageResource.Fetcher("MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Fetch(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.GET,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                MessageResource.Reader(accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestReadFullResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=119771\",\"messages\": [{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Fri, 04 Sep 2015 22:54:39 +0000\",\"date_sent\": \"Fri, 04 Sep 2015 22:54:41 +0000\",\"date_updated\": \"Fri, 04 Sep 2015 22:54:41 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}],\"next_page_uri\": null,\"num_pages\": 119772,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 119772,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\"}"));
            
            var response = MessageResource.Reader(accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestReadEmptyResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"end\": 0,\"first_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\",\"last_page_uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=119771\",\"messages\": [],\"next_page_uri\": null,\"num_pages\": 119772,\"page\": 0,\"page_size\": 1,\"previous_page_uri\": null,\"start\": 0,\"total\": 119772,\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages.json?PageSize=1&Page=0\"}"));
            
            var response = MessageResource.Reader(accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Read(twilioRestClient);
            Assert.NotNull(response);
        }
    
        [Test]
        public void TestUpdateRequest() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            var request = new Request(Twilio.Http.HttpMethod.POST,
                                          Domains.API,
                                          "/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json");
            twilioRestClient.Request(request)
                            .Returns(new Response(System.Net.HttpStatusCode.InternalServerError,
                                                  "null"));
            
            try {
                MessageResource.Updater("MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
                Assert.Fail("Expected TwilioException to be thrown for 500");
            } catch (AggregateException ae) {
                ae.Handle((e) =>
                {
                    if (e.GetType() != typeof(ApiException)) {
                        throw e;
                    }
            
                    return true;
                });
            } catch (ApiException) {
            }
            twilioRestClient.Received().Request(request);
        }
    
        [Test]
        public void TestUpdateResponse() {
            var twilioRestClient = Substitute.For<ITwilioRestClient>();
            twilioRestClient.Request(Arg.Any<Request>())
                            .Returns(new Response(System.Net.HttpStatusCode.OK,
                                                  "{\"account_sid\": \"ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"api_version\": \"2010-04-01\",\"body\": \"O Slash: \\u00d8, PoP: \\ud83d\\udca9\",\"date_created\": \"Thu, 30 Jul 2015 20:12:31 +0000\",\"date_sent\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"date_updated\": \"Thu, 30 Jul 2015 20:12:33 +0000\",\"direction\": \"outbound-api\",\"error_code\": null,\"error_message\": null,\"from\": \"+14155552345\",\"num_media\": \"0\",\"num_segments\": \"1\",\"price\": \"-0.00750\",\"price_unit\": \"USD\",\"sid\": \"SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\",\"status\": \"sent\",\"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Media.json\"},\"to\": \"+14155552345\",\"uri\": \"/2010-04-01/Accounts/ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages/SMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.json\"}"));
            
            var response = MessageResource.Updater("MMaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", accountSid: "ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa").Update(twilioRestClient);
            Assert.NotNull(response);
        }
    }
}