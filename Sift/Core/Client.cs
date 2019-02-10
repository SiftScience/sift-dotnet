using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sift
{
    public class Client : IDisposable
    {
        readonly String apiKey;
        readonly HttpClient http;

        public Client(String apiKey)
        {
            this.apiKey = apiKey;
            this.http = new HttpClient();
        }

        public Client(String apiKey, HttpClient http) {
            this.http = http;
        }

        public void Dispose()
        {
            http.Dispose();
        }

        public async Task<EventResponse> Send(EventRequest eventRequest)
        {
            return await Send<EventResponse>(eventRequest);
        }

        public async Task<ScoreResponse> Send(ScoreRequest scoreRequest)
        {
            return await Send<ScoreResponse>(scoreRequest);
        }

        public async Task<ScoreResponse> Send(RescoreRequest rescoreRequest)
        {
            return await Send<ScoreResponse>(rescoreRequest);
        }

        public async Task<SiftResponse> Send(LabelRequest labelRequest)
        {
            return await Send<SiftResponse>(labelRequest);
        }

        public async Task<SiftResponse> Send(UnlabelRequest unlabelRequest)
        {
            return await Send<SiftResponse>(unlabelRequest);
        }

        public async Task<ApplyDecisionResponse> Send(ApplyDecisionRequest applyDecisionRequest)
        {
            return await Send<ApplyDecisionResponse>(applyDecisionRequest);
        }

        public async Task<GetDecisionStatusResponse> Send(GetDecisionStatusRequest getDecisionStatusRequest)
        {
            return await Send<GetDecisionStatusResponse>(getDecisionStatusRequest);
        }

        public async Task<GetDecisionsResponse> Send(GetDecisionsRequest getDecisionsRequest)
        {
            return await Send<GetDecisionsResponse>(getDecisionsRequest);
        }

        public async Task<WorkflowStatusResponse> Send(WorkflowStatusRequest workflowStatusRequest)
        {
            return await Send<WorkflowStatusResponse>(workflowStatusRequest);
        }

        async Task<T> Send<T>(SiftRequest siftRequest) where T : SiftResponse
        {
            siftRequest.ApiKey = this.apiKey;
            HttpResponseMessage responseMessage = await http.SendAsync(siftRequest.Request);
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
