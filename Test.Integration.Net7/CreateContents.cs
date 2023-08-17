using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test
{
    public class CreateContents
    {
        [Fact]
        public void IntegrationTest_CreateContentComment()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var createContent = new CreateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "comment-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
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
            Assert.Equal("OK", res.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_CreateContentListing()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var createContent = new CreateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "listing-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                listing = new Listing()
                {
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Capitol Hill Seattle brand new condo. 2 bedrooms and 1 full bath.",
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
            Assert.Equal("OK", res.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_CreateContentMessage()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var createContent = new CreateContent
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
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US",
                message = new Message()
                {
                    subject = "2 Bedroom Apartment for Rent",
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
                            description = "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    }
                }
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = createContent
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_CreateContentPost()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var createContent = new CreateContent
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
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Let’s meet at 5pm",
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
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description = "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
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
            Assert.Equal("OK", res.ErrorMessage);
        }

    }
}
