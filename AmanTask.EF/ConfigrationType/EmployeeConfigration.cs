

namespace AmanTask.EF.ConfigrationType
{
    public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(80);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(280);
        }
    }
}
