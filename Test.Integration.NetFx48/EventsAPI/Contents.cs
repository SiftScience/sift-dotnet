﻿using Sift;
using System.Collections.ObjectModel;
using Test.Integration.NetFx48.Uitlities;
using Xunit;

namespace Test.Integration.NetFx48.EventsAPI
{
    public class Contents
    {
        private readonly EnvironmentVariable environmentVariable = new EnvironmentVariable();
        private readonly string ApiKey;
        private readonly string UserId;
        private readonly string ContentId;
        private readonly string SessionId;
        private readonly string RootContentId;
        private readonly string Md5Hash;
        private readonly string ContactEmail;
        private readonly string ItemId;
        private readonly string FlaggedBy;
        public Contents()
        {
            ApiKey = environmentVariable.ApiKey;
            UserId = environmentVariable.user_id;
            ContentId = environmentVariable.content_id;
            SessionId = environmentVariable.session_id;
            RootContentId = environmentVariable.root_content_id;
            Md5Hash = environmentVariable.md5_hash;
            ContactEmail = environmentVariable.contact_email;
            ItemId = environmentVariable.item_id;
            FlaggedBy = environmentVariable.flagged_by;
        }

        [Fact]
        public void CreateContentComment()
        {
            var sift = new Client(ApiKey);
            var createContent = new CreateContent
            {
                user_id = UserId,
                content_id = ContentId,
                session_id = SessionId,
                status = "$active",
                ip = "255.255.255.0",
                comment = new Comment()
                {
                    body = "Congrats on the new role!",
                    contact_email = "alex_301@domain.com",
                    parent_comment_id = ContentId,
                    root_content_id = RootContentId,
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = Md5Hash,
                            link = "https://www.domain.com/file.png",
                            description =   "An old picture"
                        },
                        new Image()
                        {
                            md5_hash = Md5Hash
                        }
                    }
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = createContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void CreateContentListing()
        {
            var sift = new Client(ApiKey);
            var createContent = new CreateContent
            {
                user_id = UserId,
                content_id = ContentId,
                session_id = SessionId,
                status = "$active",
                ip = "255.255.255.0",
                listing = new Listing()
                {
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Capitol Hill Seattle brand new condo. 2 bedrooms and 1 full bath.",
                    contact_email = ContactEmail,
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
                            item_id = environmentVariable.item_id,
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
                            md5_hash = environmentVariable.md5_hash,
                            link = "https://www.domain.com/file.png",
                            description =   "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = environmentVariable.md5_hash
                        }
                    },
                    expiration_time = 1549063157000
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = createContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void CreateContentMessage()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var createContent = new CreateContent
            {
                user_id = environmentVariable.user_id,
                content_id = environmentVariable.content_id,
                session_id = environmentVariable.session_id,
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US",
                message = new Message()
                {
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Let’s meet at 5pm",
                    contact_email = environmentVariable.contact_email,
                    root_content_id = RootContentId,
                    recipient_user_ids = new ObservableCollection<string>() { "fy9h989sjphh71" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = Md5Hash,
                            link = "https://www.domain.com/file.png",
                            description = "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = Md5Hash
                        }
                    }
                }
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = createContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void CreateContentPost()
        {
            var sift = new Client(ApiKey);
            var createContent = new CreateContent
            {
                user_id = UserId,
                content_id = ContentId,
                session_id = SessionId,
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
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Let’s meet at 5pm",
                    contact_email = ContactEmail,
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
                    categories = new ObservableCollection<string>() { "heat", "washer/dryer" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = Md5Hash,
                            link = "https://www.domain.com/file.png",
                            description = "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = Md5Hash
                        }
                    },
                    expiration_time = 1549063157000
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = createContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void CreateContentProfile()
        {
            var sift = new Client(ApiKey);
            var createContent = new CreateContent
            {
                user_id = UserId,
                content_id = ContentId,
                session_id = SessionId,
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                profile = new Profile()
                {
                    body = "Let’s meet at 5pm",
                    contact_email = ContactEmail,
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
                            md5_hash = Md5Hash,
                            link = "https://www.domain.com/file.png",
                            description = "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = Md5Hash
                        }
                    },
                    categories = new ObservableCollection<string>() { "Photographer", "Weddings" }
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = createContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void CreateContentReview()
        {
            var sift = new Client(ApiKey);
            var createContent = new CreateContent
            {
                user_id = UserId,
                content_id = ContentId,
                session_id = SessionId,
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                review = new Review()
                {
                    subject = "Amazing Tacos!",
                    body = "I ate the tacos.",
                    contact_email = ContactEmail,
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
                    item_reviewed = new Item()
                    {
                        item_id = ItemId,
                        product_title = "The Slanket Blanket-Texas Tea",
                        price = 39990000,
                        currency_code = "USD",
                        upc = "6786211451001",
                        sku = "004834GQ",
                        isbn = "0446576220",
                        brand = "Slanket",
                        manufacturer = "Slanket",
                        category = "Blankets & Throws",
                        tags = new ObservableCollection<string>() { "Awesome", "Wintertime specials" },
                        color = "Texas Tea",
                        size = "6",
                    },
                    reviewed_content_id = "listing-234234",
                    rating = 4.5,
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = Md5Hash,
                            link = "https://www.domain.com/file.png",
                            description = "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = Md5Hash
                        }
                    }
                },
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = createContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void ContentStatusTest()
        {
            var sift = new Client(ApiKey);
            var contentStatus = new ContentStatus
            {
                user_id = UserId,
                session_id = SessionId,
                content_id = ContentId,
                status = "$paused",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = contentStatus
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }

        [Fact]
        public void FlagContentTest()
        {
            var sift = new Client(ApiKey);
            var flagContent = new FlagContent
            {
                user_id = UserId,
                session_id = SessionId,
                content_id = ContentId,
                flagged_by = FlaggedBy,
                reason = "$toxic",
                verification_phone_number = "+123456789012"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = flagContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("0", res.Status.ToString());
        }
    }
}
