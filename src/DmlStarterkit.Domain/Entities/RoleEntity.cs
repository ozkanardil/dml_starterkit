namespace DmlStarterkit.Domain.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRoleEntity> UserRole { get; set; }
    }

}
