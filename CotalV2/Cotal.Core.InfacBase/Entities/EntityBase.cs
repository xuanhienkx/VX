using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cotal.Core.InfacBase.Entities
{
    public class EntityBase<TKey> where TKey : IEquatable<TKey>
    {
        // This is the base class for all entities.
        // The DataAccess repositories have this class as constraint for entities that are persisted in the database.

        [Key]
        public virtual TKey Id { get; set; }

        [MaxLength(10)]
        public string AppCode { get; set; } = "COTAL";

        [MaxLength(5)]
        [Column(TypeName = "varchar(5)")]
        public string LangCode { get; set; } = "vi-VN";
    }
}
