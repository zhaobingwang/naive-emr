using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NaiveEmr.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveEmr.Infrastructure.Data.Configuration
{
    public class EmrDocumentConfiguration : IEntityTypeConfiguration<EmrDocument>
    {
        public void Configure(EntityTypeBuilder<EmrDocument> builder)
        {
            builder.ToTable(d => d.HasComment("EMR文档"));

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasComment("无意义主键");
            builder.Property(d => d.Title)
                .HasComment("文档标题");
            builder.Property(d => d.JsonContent)
                .HasComment("文档内容（JSON）");
            builder.Property(d => d.CreateTime)
                .HasComment("创建时间");
            builder.Property(d => d.UpdateTime)
                .HasComment("更新时间");
        }
    }
}
