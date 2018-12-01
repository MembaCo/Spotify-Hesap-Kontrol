using System;
using System.Collections.Generic;
using System.Net;

namespace SpotifyHesapKontrol
{
    internal class HttpManager
    {
        public List<Cookie> GlobalCookies { get; private set; } = new List<Cookie>();

        public Hesap _Hesap { get; private set; }

        //CSRF TOKEN
        private string CSRF_TOKEN;

        private string SP_DC;

        //Constant URLs & USER AGENT
        private const string GET_CSRF_URL = "https://accounts.spotify.com/en/login?continue=https:%2F%2Fwww.spotify.com%2Fus%2Faccount%2Foverview%2F";

        private const string AUTH_URL = "https://accounts.spotify.com/api/login";
        private const string OVERVIEW_URL = "https://www.spotify.com/us/account/overview/";
        private const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";

        public HttpManager(Hesap _Hesap)
        {
            this._Hesap = _Hesap;
        }

        public bool CheckAccount()
        {
            CSRF_TOKEN = GetCSRFToken();

            //Update cookies
            AddCookie(CSRF_TOKEN);
            AddCookie("__bon=MHwwfC0xNDAxNTMwNDkzfC01ODg2NDI4MDcwNnwxfDF8MXwx");

            SP_DC = AuthenticateAccount();

            //Update cookies
            AddCookie(SP_DC);

            return (AccountOverview());
        }

        #region Function That Gets CSRF Token

        private string GetCSRFToken()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.UserAgent] = USER_AGENT;

                    wc.DownloadString(GET_CSRF_URL);
                    return (wc.ResponseHeaders.GetValues("Set-Cookie")[0].Split(';')[0]);
                }
            }
            catch
            {
                throw new Exception("Failed to retrieve CSRF TOKEN");
            }
        }

        #endregion Function That Gets CSRF Token

        #region AuthenticatesAccountAndReturnsCookie

        private string AuthenticateAccount()
        {
            string PostData = $"&username={_Hesap.KulAdi}&password={_Hesap.Sifre}&remember=true&{CSRF_TOKEN}";

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.UserAgent] = USER_AGENT;
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.Headers[HttpRequestHeader.Accept] = "application/json, text/plain, */*";
                //Add cookies
                GlobalCookies.ForEach(c => wc.Headers.Add(HttpRequestHeader.Cookie, c.ToString()));

                try
                {
                    wc.UploadString(AUTH_URL, PostData);
                    //System.Windows.Forms.MessageBox.Show(wc.ResponseHeaders.GetValues("Set-Cookie")[1].Split(';')[0]);
                    return (wc.ResponseHeaders.GetValues("Set-Cookie")[1].Split(';')[0]);
                }
                catch
                {
                    throw new Exception("Invalid Account.");
                }
            }
        }

        #endregion AuthenticatesAccountAndReturnsCookie

        #region AccountOverview

        private bool AccountOverview()
        {
            try
            {
                string PostData = $"&username={_Hesap.KulAdi}&password={_Hesap.Sifre}&remember=true&{CSRF_TOKEN}";

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.UserAgent] = USER_AGENT;

                    foreach (Cookie _Cookie in GlobalCookies)
                    {
                        string CookieString = _Cookie.ToString();
                        if (CookieString.StartsWith("sp_dc"))
                        {
                            wc.Headers.Add(HttpRequestHeader.Cookie, CookieString);
                            break;
                        }
                    }

                    string ResponseHTML = wc.UploadString(OVERVIEW_URL, PostData);

                    return (
                        ResponseHTML.Contains("<h1>Account overview</h1>") &&
                        (ResponseHTML.Contains("/svg></span>Spotify Premium") ||
                        ResponseHTML.Contains("</svg></span>Spotify For Family"))
                        //ResponseHTML.Contains("<span class=\"icon - checkmark - wrap\"><svg><use xlink:href=\"#icon-checkmark\"></use></svg></span>Spotify Premium</h3><p class=\"subscription-status subscription-compact\">")
                        //!(ResponseHTML.Contains("You&#039;re currently Spotify Free.") ||
                        //ResponseHTML.Contains("Premium Paused"))
                        );
                }
            }
            catch
            {
                throw new Exception("Failed to retrieve Account Overview PAGE");
            }
        }

        #endregion AccountOverview

        #region AddCookieToGlobalFunction

        private void AddCookie(string CookieToAdd)
        {
            string[] CookieContents = CookieToAdd.Split('=');
            GlobalCookies.Add(new Cookie(CookieContents[0], CookieContents[1]));
        }

        #endregion AddCookieToGlobalFunction
    }
}