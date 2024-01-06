namespace WatsAppIntegration.Config
{
    public class FaceBookGraphApiConfig
    {
        public string GraphApiUrl { get; set; }//https://graph.facebook.com/v17.0/184597484744010/messages

        public FaceBookMsgGraphApiConfig WatsAppApi { get; set; }
    }
}
