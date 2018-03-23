using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiDemo.Models;

namespace ApiDemo.Controllers
{
    public class AuthenticateController : ApiController
    {
        IAuthenticate _IAuthenticate;
        public AuthenticateController()
        {
            _IAuthenticate = new AuthenticateConcrete();
        }

        // POST: api/Authenticate
        public HttpResponseMessage Authenticate([FromBody]ClientKeys ClientKeys)
        {
            
                if (string.IsNullOrEmpty(ClientKeys.ClientID) && string.IsNullOrEmpty(ClientKeys.ClientSecret))
                {
                    var message = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                    message.Content = new StringContent("Not Valid Request");
                    return message;
                }
                else
                {
                    if (_IAuthenticate.ValidateKeys(ClientKeys))
                    {
                        var clientkeys = _IAuthenticate.GetClientKeysDetailsbyCLientIDandClientSecert(ClientKeys.ClientID, ClientKeys.ClientSecret);

                        if (clientkeys == null)
                        {
                            var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                            message.Content = new StringContent("InValid Keys");
                            return message;
                        }
                        else
                        {
                            if (_IAuthenticate.IsTokenAlreadyExists(clientkeys.CompanyID))
                            {
                                _IAuthenticate.DeleteGenerateToken(clientkeys.CompanyID);

                                return GenerateandSaveToken(clientkeys);
                            }
                            else
                            {
                                return GenerateandSaveToken(clientkeys);
                            }
                        }
                    }
                    else
                    {
                        var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                        message.Content = new StringContent("InValid Keys");
                        return new HttpResponseMessage { StatusCode = HttpStatusCode.NotAcceptable };
                    }
                }
           
        }


        [NonAction]
        private HttpResponseMessage GenerateandSaveToken(ClientKeys clientkeys)
        {
            var IssuedOn = DateTime.Now;
            var newToken = _IAuthenticate.GenerateToken(clientkeys, IssuedOn);
            TokensManager token = new TokensManager();
            token.TokenID = 0;
            token.TokenKey = newToken;
            token.CompanyID = clientkeys.CompanyID;
            token.IssuedOn = IssuedOn;
            token.ExpiresOn = DateTime.Now.AddMinutes(10);
            token.CreatedOn = DateTime.Now;
            var result = _IAuthenticate.InsertToken(token);

            if (result == 1)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
                response.Headers.Add("Token", newToken);
                response.Headers.Add("TokenExpiry", "10");
                response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                return response;
            }
            else
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                message.Content = new StringContent("Error in Creating Token");
                return message;
            }
        }
    }
}
