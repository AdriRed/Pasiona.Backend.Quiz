using SocialGames.TechnicalTest.Resources.Common;

namespace SocialGames.TechnicalTest.Games.Resources.Common.Errors
{
    public class ValidationErrorResource : ErrorResource
    {
        public string Field { get => (string)Properties[nameof(Field)]; set => Properties[nameof(Field)] = value; }
        public string[] Reasons { get => (string[])Properties[nameof(Reasons)]; set => Properties[nameof(Reasons)] = value; }
    }
}