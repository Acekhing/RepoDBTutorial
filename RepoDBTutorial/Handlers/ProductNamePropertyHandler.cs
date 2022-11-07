using Microsoft.IdentityModel.Tokens;
using RepoDb.Interfaces;
using RepoDb.Options;

namespace RepoDBTutorial.Handlers
{
    public class ProductNamePropertyHandler : IPropertyHandler<string?, string>
    {
        public string Get(string? input, PropertyHandlerGetOptions options)
        {
            return input.IsNullOrEmpty() ? "Name not provided" : input;
        }

        public string? Set(string input, PropertyHandlerSetOptions options)
        {
            return input.IsNullOrEmpty() ? "N/A": input;
        }
    }
}
