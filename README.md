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


    // Construct reserved events with known fields for UpdateContent.Comment
    var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "comment-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                comment = new Comment()
                {
                    body = "Congrats on the new role!",
                    contact_email = "alex_301@domain.com",
                    parent_comment_id = "comment-23407",
                    root_content_id = "listing-12923213",
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "An old picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    }
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = updateContent
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }


    // Construct reserved events with known fields for UpdateContent.Listing
                var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "listing-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                listing = new Listing()
                {
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Capitol Hill Seattle brand new condo. 2 bedrooms and 1 full bath.",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Bill Jones",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"


                    },
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    listed_items = new ObservableCollection<Item>()
                    {
                        new Item()
                        {
                            item_id = "0cc175b9c0f1b6a831c399e269772661",
                            product_title = "https://www.domain.com/file.png",
                            price = 2950000000,
                            currency_code = "USD",
                            quantity = 1,
                            upc = "6786211451001",
                            sku = "abc",
                            isbn = "0446576220",
                            brand = "abc",
                            manufacturer = "abc",
                            category = "abc",
                            tags = new ObservableCollection<string>() { "heat","washer/dryer" },
                            color = "ab",
                            size = "ab"
                        }
                    },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    expiration_time = 1549063157000
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = updateContent
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }

        // Construct reserved events with known fields for UpdateContent.Message
    var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "message-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                message = new Message()
                {
                    body = "Let’s meet at 5pm",
                    contact_email = "alex_301@domain.com",
                    root_content_id = "listing-123",
                    recipient_user_ids = new ObservableCollection<string>() { "fy9h989sjphh71" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "My hike today!"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = updateContent
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }


    // Construct reserved events with known fields for UpdateContent.Post
    var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "post-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                post = new Post()
                {
                    subject = "My new apartment!",
                    body = "Moved into my new apartment yesterday.",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Bill Jones",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"
                    },
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    categories = new ObservableCollection<string>() { "Personal" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "View from the window!"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    expiration_time = 1549063157000
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = updateContent
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }

        // Construct reserved events with known fields for UpdateContent.Profile
    var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "listing-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                profile = new Profile()
                {
                    body = "Hi! My name is Alex and I just moved to New London!",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Alex Smith",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"
                    },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description = "Alex’s picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    categories = new ObservableCollection<string>() { "Friends", "Long-term dating" }
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = updateContent
            };
            try
            {
                EventResponse res = sift.SendAsync(eventRequest).Result;
            }
            catch (AggregateException ae)
            {
                // Handle InnerException
            }
        }

#### IncludeScorePercentile in EventRequest

      EventRequest eventRequest = new EventRequest
      {
        Event = transaction,
        AbuseTypes = { "legacy", "payment_abuse" },
        IncludeScorePercentile = true, // this will include the relevant parameters in the url query string to get the SCORE_PERCENTILE
        ReturnScore = true
      };

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

#### Percentile
     [JsonProperty("percentiles")]
    public Dictionary<string, decimal> Percentiles { get; set; }

    It's a collection of type dictionary with string Key and a decimal Value

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
