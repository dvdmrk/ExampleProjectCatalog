using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    /// <summary>
    /// All named database entities will inherit from this class.
    /// </summary>
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}