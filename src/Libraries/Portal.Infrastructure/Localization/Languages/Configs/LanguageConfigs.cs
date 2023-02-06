using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Localization;

namespace Portal.Infrastructure.Localization.Languages.Configs;

internal class LanguageConfigs : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(_=>_.Id);

        builder.Property(_ => _.Name).IsRequired().HasMaxLength(250);
        builder.Property(_=>_.Title).IsRequired().HasMaxLength(10);
        
    }
}

