namespace MotorMenezes.Core.Helpers
{
    public static class Validation
    {

        public static Guid ValidateIdExterno(string idExternal)
        {
            Guid idExternalGuid;
            Guid.TryParse(idExternal, out idExternalGuid);

            return idExternalGuid;
        }
    }
}
