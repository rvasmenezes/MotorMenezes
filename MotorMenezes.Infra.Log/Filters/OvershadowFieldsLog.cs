namespace MotorMenezes.Infra.Log.Filters
{
    public class OvershadowFieldsLog : Attribute
    {
        public string Fields { get; set; }

        public OvershadowFieldsLog(string fields)
        {
            Fields = fields;
        }
    }
}
