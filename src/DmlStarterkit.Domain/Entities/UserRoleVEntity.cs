namespace DmlStarterkit.Domain.Entities
{
    public class UserRoleVEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClaimId { get; set; }
        public string OperationName { get; set; }
    }
}
