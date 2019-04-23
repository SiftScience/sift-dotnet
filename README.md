# sift-dotnet

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/sift.svg)](https://www.nuget.org/packages/Sift)
[![CircleCI](https://circleci.com/gh/SiftScience/sift-dotnet.svg?style=svg)](https://circleci.com/gh/SiftScience/sift-dotnet)

The official Sift .NET client, supporting .NET Standard 2.0+

## Documentation

### Initialization

    // You can also pass in your own HttpClient implementation as the second parameter.
    // Dispose() will dispose of the HttpClient instance.
    var sift = new Client("REST_API_KEY");
    
### Reserved Events

    // Construct reserved events with known fields
    var createOrder = new CreateOrder
    {
        user_id = "gary",
        order_id = "oid",
        amount = 1000000,
        currency_code = "USD",
        billing_address = new Address {
            name = "gary",
            city = "san francisco"
        },
        app = new App {
            app_name = "my app",
            app_version = "1.0"
        },
        items = new ObservableCollection<Item>() { new Item{sku="abc"}, new Item{sku="abc"} }
    };

    // Augment with custom fields
    createOrder.AddField("foo", "bar");

    try 
    {
        EventResponse res = sift.SendAsync(new EventRequest
        {
            Event = createOrder,
            ReturnScore = true,
            AbuseTypes = new List<string>() { "payment_abuse", "account_takeover" }
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }

### Custom Events

    // Construct custom events with required fields
    var makeCall = new CustomEvent
    {
        type = "make_call",
        user_id = "gary"
    };

    // Augment with custom fields
    makeCall.AddFields(new Dictionary<string, object>
    {
        ["foo"] = "bar",
        ["payment_status"] = "$success"
    });

    try
    {
        EventResponse res = sift.SendAsync(new EventRequest
        {
            Event = makeCall
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }
    
### Decisions

    // Apply Decision
    try
    {
        ApplyDecisionResponse response = sift.SendAsync(new ApplyUserDecisionRequest
        {
            AccountId = "ACCOUNT_ID",
            UserId = "gary",
            DecisionId = "DECISION_ID",
            Source = "AUTOMATED_RULE"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }



    // Get Decision Status
    try
    {
        GetDecisionStatusResponse response = sift.SendAsync(new GetDecisionStatusRequest
        {
            AccountId = "ACCOUNT_ID",
            UserId = "gary"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }

    // Get Decisions
    try
    {
        GetDecisionsResponse response = sift.SendAsync(new GetDecisionsRequest
        {
            AccountId = "ACCOUNT_ID"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }

### Workflows

    // Workflow Status
    try
    {
        WorkflowStatusResponse response = sift.SendAsync(new WorkflowStatusRequest
        {
            AccountId = "ACCOUNT_ID",
            WorkflowRunId = "WORKFLOW_RUN_ID"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }

### Scores

    // Get score
    try
    {
        ScoreResponse res = sift.SendAsync(new ScoreRequest
        {
            UserId = "gary"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }

    // Rescore
    try
    {
        ScoreResponse res = sift.SendAsync(new RescoreRequest
        {
            UserId = "gary"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }

### Labels

    // Label
    try
    {
        SiftResponse response = sift.SendAsync(new LabelRequest
        {
            UserId = "gary",
            IsBad = true,
            AbuseType = "payment_abuse"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }

    // Unlabel
    try
    {
        SiftResponse response = sift.SendAsync(new UnlabelRequest
        {
            UserId = "gary",
            AbuseType = "payment_abuse"
        }).Result;
    }
    catch (AggregateException ae)
    {
        // Handle InnerException
    }
