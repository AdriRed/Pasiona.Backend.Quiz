namespace SocialGames.TechnicalTest.Resources.Common.Errors
{
    public class FatalErrorResource : ErrorResource
    {
        public FatalErrorResource()
        {
            this.Type = ErrorType.Fatal;
        }
        public string Exception { get => (string)Properties[nameof(Exception)]; set => Properties[nameof(Exception)] = value; }
    }
}