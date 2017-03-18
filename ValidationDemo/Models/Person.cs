using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationDemo.Models
{
    public class Person
    {
        [Required(ErrorMessage = "不能为空")]
        [Range(10,100,ErrorMessage = "只能输入10-100")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}