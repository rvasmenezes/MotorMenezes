namespace MotorMenezes.Core.ApplicationContext
{
    public interface IMotorMenezesContext
    {
        public string UserLoggedId { get; }
        public string UserLoggedEmail { get; }
        public string RoleUserLogged { get; }
        public string? UserLoggedName { get; }
    }
}
