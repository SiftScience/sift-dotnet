using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test
{
    public class Cart
    {
        [Fact]
        public void AddItemToCartEvent()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var addItemToCart = new AddItemToCart
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                item = new Item()
                {
                    item_id = "B004834GQO",
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
                    quantity = 16,
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
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = addItemToCart
            };

            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }


        [Fact]
        public void RemoveItemFromCart()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var removeItemFromCart = new RemoveItemFromCart
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                item = new Item()
                {
                    item_id = "B004834GQO",
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
                    quantity = 2
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
                verification_phone_number = "+123456789012"
            };

            EventRequest eventRequest = new EventRequest()
            {
                Event = removeItemFromCart
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}
