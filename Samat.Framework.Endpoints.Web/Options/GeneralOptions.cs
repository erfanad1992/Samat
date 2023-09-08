namespace Samat.Framework.Endpoints.Web.Options
{
    public class GeneralOptions
    {
        public static readonly string General = nameof(GeneralOptions).Replace("Options", "");

        public bool ErrorExceptionInResult { get; set; }

    }
}