using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sift
{
    public class Client : IDisposable
    {
        static string UserAgent = "sift-dotnet/" + Assembly.GetExecutingAssembly().GetName().Version;

        readonly String apiKey;
        readonly HttpClient http;

        public Client(String apiKey)
        {
            this.apiKey = apiKey;
            this.http = new HttpClient();
        }

        public Client(String apiKey, HttpClient http) {
            this.apiKey = apiKey;
            this.http = http;
        }

        public void Dispose()
        {
            http.Dispose();
        }

        public async Task<EventResponse> SendAsync(EventRequest eventRequest)
        {
            return await SendAsync<EventResponse>(eventRequest);
        }

        public async Task<ScoreResponse> SendAsync(ScoreRequest scoreRequest)
        {
            return await SendAsync<ScoreResponse>(scoreRequest);
        }

        public async Task<ScoreResponse> SendAsync(RescoreRequest rescoreRequest)
        {
            return await SendAsync<ScoreResponse>(rescoreRequest);
        }

        public async Task<SiftResponse> SendAsync(LabelRequest labelRequest)
        {
            return await SendAsync<SiftResponse>(labelRequest);
        }

        public async Task<SiftResponse> SendAsync(UnlabelRequest unlabelRequest)
        {
            return await SendAsync<SiftResponse>(unlabelRequest);
        }

        public async Task<ApplyDecisionResponse> SendAsync(ApplyDecisionRequest applyDecisionRequest)
        {
            return await SendAsync<ApplyDecisionResponse>(applyDecisionRequest);
        }

        public async Task<GetDecisionStatusResponse> SendAsync(GetDecisionStatusRequest getDecisionStatusRequest)
        {
            return await SendAsync<GetDecisionStatusResponse>(getDecisionStatusRequest);
        }

        public async Task<GetDecisionsResponse> SendAsync(GetDecisionsRequest getDecisionsRequest)
        {
            return await SendAsync<GetDecisionsResponse>(getDecisionsRequest);
        }

        public async Task<WorkflowStatusResponse> SendAsync(WorkflowStatusRequest workflowStatusRequest)
        {
            return await SendAsync<WorkflowStatusResponse>(workflowStatusRequest);
        }
        public async Task<VerificationCheckResponse> SendAsync(VerificationCheckRequest verificationCheckRequest)
        {
            return await SendAsync<VerificationCheckResponse>(verificationCheckRequest);
        }

        public async Task<VerificationSendResponse> SendAsync(VerificationSendRequest verificationSendRequest)
        {
            return await SendAsync<VerificationSendResponse>(verificationSendRequest);
        }

        public async Task<VerificationReSendResponse> SendAsync(VerificationReSendRequest verificationReSendRequest)
        {
            return await SendAsync<VerificationReSendResponse>(verificationReSendRequest);
        }

        public async Task<GetMerchantsResponse> SendAsync(GetMerchantsRequest getMerchantRequest)
        {
            return await SendAsync<GetMerchantsResponse>(getMerchantRequest);
        }

        public async Task<CreateMerchantResponse> SendAsync(CreateMerchantRequest createMerchantRequest)
        {
            return await SendAsync<CreateMerchantResponse>(createMerchantRequest);
        }

        public async Task<UpdateMerchantResponse> SendAsync(UpdateMerchantRequest updateMerchantRequest)
        {
            return await SendAsync<UpdateMerchantResponse>(updateMerchantRequest);
        }

        public async Task<GetMerchantDetailsResponse> SendAsync(GetMerchantDetailsRequest getMerchantRequest)
        {
            return await SendAsync<GetMerchantDetailsResponse>(getMerchantRequest);
        }

        async Task<T> SendAsync<T>(SiftRequest siftRequest) where T : SiftResponse
        {
            siftRequest.ApiKey = this.apiKey;

            // Note: we deference this once and augment the result, since the
            // disparity in HTTP headers per API is handled upstream.
            HttpRequestMessage request = siftRequest.Request;

            request.Headers.UserAgent.ParseAdd(UserAgent);

            HttpResponseMessage responseMessage = await http.SendAsync(request).ConfigureAwait(false);

            return (T)ProcessResponse(
                JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync()),
                (int)responseMessage.StatusCode);
        }

        SiftResponse ProcessResponse(SiftResponse siftResponse, int httpStatusCode) {
            // Handle success with no content
            if (siftResponse == null && httpStatusCode == 204) {
                siftResponse = new SiftResponse
                {
                    Status = 0
                };
            }

            // Handle REST errors
            if (siftResponse.Status.HasValue && siftResponse.Status != 0)
            {
                if (httpStatusCode >= 500 && httpStatusCode < 600)
                {
                    throw new ServerException(siftResponse);
                }
                else if (httpStatusCode >= 400 && httpStatusCode < 500)
                {
                    switch (siftResponse.Status.Value)
                    {
                        case -4:
                        case -3:
                        case -2:
                        case -1:
                            throw new ServerException(siftResponse);
                        case 51:
                            throw new InvalidApiKeyException(siftResponse);
                        case 52:
                        case 53:
                        case 105:
                            throw new InvalidFieldException(siftResponse);
                        case 55:
                            throw new MissingFieldException(siftResponse);
                        case 56:
                        case 57:
                        case 104:
                            throw new InvalidRequestException(siftResponse);
                        case 60:
                            throw new RateLimitException(siftResponse);
                    }
                }

                throw new SiftException(siftResponse);
            }

            // Handle v3 errors
            if (siftResponse.Error != null) {
                throw new SiftException(siftResponse);
            }

            return siftResponse;
        }
    }
}
