using System.Net;

[Serializable]
internal class HttpResponseException : Exception
{
    private HttpStatusCode internalServerError;
    private object msg;

    public HttpResponseException(HttpStatusCode internalServerError, object msg)
    {
        this.internalServerError = internalServerError;
        this.msg = msg;
    }
}