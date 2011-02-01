using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace System.Web.Mvc.Html
{
    public static class Gravatar
    {
        public static MvcHtmlString GetGravatarTag(this HtmlHelper helper, string email, int size, string link, string rating = "PG", string alt = "Gravatar", string title = "Gravatar", string cssClass = "gravatar")
        {
            var baseURL = "http://www.gravatar.com/avatar/{0}?s={1}&d=identicon&r={2}";
            TagBuilder href = new TagBuilder("a");
            href.Attributes.Add("href", link);

            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", string.Format(baseURL, MD5String(email), size.ToString(), rating));
            img.Attributes.Add("alt", alt);
            img.Attributes.Add("title", title);
            img.AddCssClass(cssClass);

            href.InnerHtml = img.ToString();

            return MvcHtmlString.Create(href.ToString());

        }

        public static string MD5String(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
